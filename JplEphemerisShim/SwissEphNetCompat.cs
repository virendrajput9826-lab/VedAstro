// JplEphemerisShim/SwissEphNetCompat.cs
// Provides namespace SwissEphNet with SwissEph class inheriting from SwissEphShim.
// This guarantees 100% zero-modification drop-in compatibility for existing code.

namespace SwissEphNet
{
    public class SwissEph : JplEphemerisShim.SwissEphShim
    {
        public SwissEph() : base() { }
        public SwissEph(string path) : base(path) { }
    }
}
