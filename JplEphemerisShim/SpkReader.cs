// JplEphemerisShim/SpkReader.cs
// Clean-room reader for JPL DE440s.bsp (DAF/SPK Type 2 — Chebyshev polynomials).
// Reads the binary SPK file directly to compute planetary barycentric positions.
//
// DAF/SPK format reference: JPL IOM 312.N-03-009 (publicly available NASA document).
// No Swiss Ephemeris, SPICE toolkit, or AGPL code is referenced.

using System.Buffers.Binary;

namespace JplEphemerisShim;

/// <summary>
/// Reads a JPL SPK (Type 2) ephemeris file and evaluates Chebyshev polynomials
/// to compute body positions (x, y, z) in km relative to a center body.
/// </summary>
public sealed class SpkReader : IDisposable
{
    private readonly FileStream _stream;
    private readonly BinaryReader _reader;
    private readonly List<SpkSegment> _segments = new();

    // NAIF body codes used by DE440s
    public const int SUN = 10;
    public const int MERCURY_BARYCENTER = 1;
    public const int VENUS_BARYCENTER = 2;
    public const int EARTH_MOON_BARYCENTER = 3;
    public const int MARS_BARYCENTER = 4;
    public const int JUPITER_BARYCENTER = 5;
    public const int SATURN_BARYCENTER = 6;
    public const int URANUS_BARYCENTER = 7;
    public const int NEPTUNE_BARYCENTER = 8;
    public const int MOON = 301;
    public const int EARTH = 399;

    // Swiss Ephemeris planet indices (for compatibility with VedAstro's swe_calc calls)
    public const int SE_SUN = 0;
    public const int SE_MOON = 1;
    public const int SE_MERCURY = 2;
    public const int SE_VENUS = 3;
    public const int SE_MARS = 4;
    public const int SE_JUPITER = 5;
    public const int SE_SATURN = 6;
    public const int SE_URANUS = 7;
    public const int SE_NEPTUNE = 8;
    public const int SE_MEAN_NODE = 10;  // Rahu (Mean Lunar Node)
    public const int SE_TRUE_NODE = 11;

    public SpkReader(string spkFilePath)
    {
        _stream = new FileStream(spkFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        _reader = new BinaryReader(_stream);
        ParseDafHeader();
    }

    #region DAF Parsing

    private int _recordSize; // in doubles (typically 1024 for DE440s)
    private int _numSummaryDoubles; // ND (typically 2)
    private int _numSummaryInts;    // NI (typically 6)

    private void ParseDafHeader()
    {
        // DAF file record 1: header
        _stream.Seek(0, SeekOrigin.Begin);
        byte[] headerBytes = _reader.ReadBytes(1024 * 8);

        // Bytes 0-7: "DAF/SPK " or "NAIF/DAF" locator
        string locator = System.Text.Encoding.ASCII.GetString(headerBytes, 0, 8).Trim();

        // Bytes 8-11: ND (number of double components per summary)
        _numSummaryDoubles = BitConverter.ToInt32(headerBytes, 8);

        // Bytes 12-15: NI (number of integer components per summary)
        _numSummaryInts = BitConverter.ToInt32(headerBytes, 12);

        // Bytes 76-79: initial summary record number (1-indexed)
        int fwdPtr = BitConverter.ToInt32(headerBytes, 76);

        // Record size for DAF is always 1024 bytes (128 doubles)
        _recordSize = 128;

        // Parse summary records (linked list of summary record blocks)
        ParseSummaryRecords(fwdPtr);
    }

    private void ParseSummaryRecords(int recordNumber)
    {
        int summarySize = _numSummaryDoubles + (_numSummaryInts + 1) / 2;
        // each summary = ND doubles + NI ints, packed into (ND + (NI+1)/2) doubles

        while (recordNumber > 0)
        {
            long offset = (long)(recordNumber - 1) * _recordSize * 8;
            _stream.Seek(offset, SeekOrigin.Begin);
            byte[] recordBytes = _reader.ReadBytes(_recordSize * 8);

            // First double: next summary record number (0 = end of list)
            double nextRecord = BitConverter.ToDouble(recordBytes, 0);
            // Second double: previous summary record number
            // Third double: number of summaries in this record
            double numSummaries = BitConverter.ToDouble(recordBytes, 16);

            int nSummaries = (int)numSummaries;
            int byteOffset = 24; // summaries start after the 3 control doubles

            for (int i = 0; i < nSummaries; i++)
            {
                // Read ND doubles
                double[] dVals = new double[_numSummaryDoubles];
                for (int d = 0; d < _numSummaryDoubles; d++)
                {
                    dVals[d] = BitConverter.ToDouble(recordBytes, byteOffset);
                    byteOffset += 8;
                }

                // Read NI integers
                int[] iVals = new int[_numSummaryInts];
                for (int j = 0; j < _numSummaryInts; j++)
                {
                    iVals[j] = BitConverter.ToInt32(recordBytes, byteOffset);
                    byteOffset += 4;
                }
                // Pad to next double boundary if NI is odd
                if (_numSummaryInts % 2 != 0)
                    byteOffset += 4;

                // DE440s SPK segment summary:
                // dVals[0] = start epoch (seconds past J2000 TDB)
                // dVals[1] = end epoch
                // iVals[0] = target body NAIF code
                // iVals[1] = center body NAIF code
                // iVals[2] = reference frame (1 = J2000)
                // iVals[3] = SPK type (2 = Chebyshev)
                // iVals[4] = start word index (1-indexed) in file
                // iVals[5] = end word index

                _segments.Add(new SpkSegment
                {
                    StartEpoch = dVals[0],
                    EndEpoch = dVals[1],
                    TargetBody = iVals[0],
                    CenterBody = iVals[1],
                    SpkType = iVals[3],
                    StartWord = iVals[4],
                    EndWord = iVals[5],
                });
            }

            recordNumber = (int)nextRecord;
        }
    }

    #endregion

    #region Chebyshev Evaluation

    /// <summary>
    /// Compute position (x, y, z) in km for a body at a given epoch.
    /// Epoch is Julian Day TDB.
    /// </summary>
    public (double X, double Y, double Z) GetPosition(int targetBody, int centerBody, double jdTdb)
    {
        // Convert JD TDB to seconds past J2000.0 TDB
        double etSec = (jdTdb - 2451545.0) * 86400.0;

        // Find the segment for this body pair and time
        SpkSegment? seg = FindSegment(targetBody, centerBody, etSec);
        if (seg == null)
        {
            throw new InvalidOperationException(
                $"No SPK segment found for target={targetBody} center={centerBody} at JD={jdTdb:F6}");
        }

        return EvaluateType2(seg, etSec);
    }

    private SpkSegment? FindSegment(int target, int center, double etSec)
    {
        foreach (var seg in _segments)
        {
            if (seg.TargetBody == target && seg.CenterBody == center
                && seg.SpkType == 2
                && etSec >= seg.StartEpoch && etSec <= seg.EndEpoch)
            {
                return seg;
            }
        }
        return null;
    }

    private (double X, double Y, double Z) EvaluateType2(SpkSegment seg, double etSec)
    {
        // Read the segment metadata (last 4 doubles of the segment's data array)
        // These are: initial_epoch, interval_length, record_size_minus_2, num_records
        long endByteOffset = (long)(seg.EndWord - 1) * 8;
        _stream.Seek(endByteOffset - 3 * 8, SeekOrigin.Begin);

        byte[] metaBytes = _reader.ReadBytes(4 * 8);
        double initEpoch = BitConverter.ToDouble(metaBytes, 0);
        double intervalLen = BitConverter.ToDouble(metaBytes, 8);
        double rsizeDbl = BitConverter.ToDouble(metaBytes, 16);
        double numRecords = BitConverter.ToDouble(metaBytes, 24);

        int rsize = (int)rsizeDbl; // full record size in doubles
        int nCoeffs = (rsize - 2) / 3; // Chebyshev order per component

        // Determine which record (time interval) contains our epoch
        int recordIndex = (int)((etSec - initEpoch) / intervalLen);
        if (recordIndex >= (int)numRecords) recordIndex = (int)numRecords - 1;
        if (recordIndex < 0) recordIndex = 0;

        // Read the Chebyshev coefficient record
        long startByte = (long)(seg.StartWord - 1) * 8;
        long recordByte = startByte + (long)recordIndex * rsize * 8;
        _stream.Seek(recordByte, SeekOrigin.Begin);
        byte[] recBytes = _reader.ReadBytes(rsize * 8);

        double[] record = new double[rsize];
        for (int i = 0; i < rsize; i++)
        {
            record[i] = BitConverter.ToDouble(recBytes, i * 8);
        }

        // record[0] = midpoint of this interval (seconds past J2000 TDB)
        // record[1] = radius (half-length) of this interval
        double midpoint = record[0];
        double radius = record[1];

        // Chebyshev coefficients for X start at record[2], Y at record[2+nCoeffs], Z at record[2+2*nCoeffs]
        // Normalized time: tau = (et - midpoint) / radius, in [-1, 1]
        double tau = (etSec - midpoint) / radius;
        if (tau < -1.0) tau = -1.0;
        if (tau > 1.0) tau = 1.0;

        double x = EvaluateChebyshev(record, 2, nCoeffs, tau);
        double y = EvaluateChebyshev(record, 2 + nCoeffs, nCoeffs, tau);
        double z = EvaluateChebyshev(record, 2 + 2 * nCoeffs, nCoeffs, tau);

        return (x, y, z);
    }

    /// <summary>
    /// Evaluate a Chebyshev polynomial of the first kind using Clenshaw's recurrence.
    /// coeffs are at array[startIndex .. startIndex + count - 1].
    /// tau is the normalized time in [-1, 1].
    /// </summary>
    private static double EvaluateChebyshev(double[] array, int startIndex, int count, double tau)
    {
        // Clenshaw recurrence: T_n(x) evaluation
        double bk1 = 0.0;
        double bk2 = 0.0;

        for (int k = count - 1; k >= 1; k--)
        {
            double bk = 2.0 * tau * bk1 - bk2 + array[startIndex + k];
            bk2 = bk1;
            bk1 = bk;
        }

        return tau * bk1 - bk2 + array[startIndex];
    }

    #endregion

    public void Dispose()
    {
        _reader.Dispose();
        _stream.Dispose();
    }

    private class SpkSegment
    {
        public double StartEpoch { get; init; }
        public double EndEpoch { get; init; }
        public int TargetBody { get; init; }
        public int CenterBody { get; init; }
        public int SpkType { get; init; }
        public int StartWord { get; init; }
        public int EndWord { get; init; }
    }
}
