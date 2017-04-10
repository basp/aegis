namespace Aegis.Shp
{
    using System.IO;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct Point
    {
        public double X;
        public double Y;

        public static Point Read(BinaryReader reader)
        {
            return new Point
            {
                X = reader.ReadDoubleNdr(),
                Y = reader.ReadDoubleNdr(),
            };
        }
    }
}
