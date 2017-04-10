namespace Aegis.Shp
{
    using System.IO;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct PointRecord
    {
        public int ShapeType;
        public Point Point;

        public static PointRecord Read(BinaryReader reader)
        {
            return new PointRecord
            {
                ShapeType = reader.ReadInt32Ndr(),
                Point = Point.Read(reader),
            };
        }
    }
}
