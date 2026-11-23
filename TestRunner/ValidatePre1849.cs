using System;
using System.IO;
using System.Reflection;
using JplEphemerisShim;

namespace TestRunner;

public static class ValidatePre1849
{
    public static void Run()
    {
        string dllPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Desktop\MacOS\Launcher2.app\Contents\Resources\api-build\SwissEphNet.dll"));
        if (!File.Exists(dllPath))
        {
            Console.WriteLine($"SwissEphNet.dll not found at: {dllPath}");
            return;
        }

        var asm = Assembly.LoadFrom(dllPath);
        var sweType = asm.GetType("SwissEphNet.SwissEph");
        var sweInstance = Activator.CreateInstance(sweType!);
        var sweCalcMethod = sweType!.GetMethod("swe_calc", new[] { typeof(double), typeof(int), typeof(int), typeof(double[]), typeof(string).MakeByRefType() });
        var sweJuldayMethod = sweType.GetMethod("swe_julday", new[] { typeof(int), typeof(int), typeof(int), typeof(double), typeof(int) });

        var dates = new[]
        {
            (1800, 1, 1, 12.0),
            (1816, 7, 19, 1.75), // ChatussagaraYogaHoroscope1
            (1830, 6, 15, 6.5),
            (1845, 12, 31, 0.0)
        };

        var planets = new[]
        {
            (0, "Sun"),
            (1, "Moon"),
            (2, "Mercury"),
            (3, "Venus"),
            (4, "Mars"),
            (5, "Jupiter"),
            (6, "Saturn")
        };

        Console.WriteLine("=========================================================================================");
        Console.WriteLine(" PRE-1849 ACCURACY AUDIT: Standish Keplerian Fallback vs SwissEphNet Moshier");
        Console.WriteLine("=========================================================================================");

        foreach (var (y, m, d, h) in dates)
        {
            object[] jdArgs = new object[] { y, m, d, h, 1 };
            double jd = (double)sweJuldayMethod!.Invoke(sweInstance, jdArgs)!;
            Console.WriteLine($"\n--- Date: {y}-{m:02d}-{d:02d} {h:04.1f}h UT (JD {jd:F4}) ---");

            foreach (var (ipl, name) in planets)
            {
                // SwissEph
                double[] results = new double[6];
                object[] calcArgs = new object[] { jd, ipl, 2, results, "" };
                sweCalcMethod!.Invoke(sweInstance, calcArgs);
                double sweLon = results[0];

                // Standish fallback
                var (fallLon, fallLat, fallDist) = CoordinateTransforms.AnalyticalGeocentricEcliptic(ipl, jd);

                double diffDeg = Math.Abs(fallLon - sweLon);
                if (diffDeg > 180.0) diffDeg = 360.0 - diffDeg;
                double diffArcmin = diffDeg * 60.0;
                double diffArcsec = diffDeg * 3600.0;

                Console.WriteLine($"  {name,-8}: Fallback={fallLon,8:F3}° SwissEph={sweLon,8:F3}° Diff={diffArcmin,6:F2}' ({diffArcsec,6:F1}\")");
            }
        }
        Console.WriteLine("=========================================================================================");
    }
}
