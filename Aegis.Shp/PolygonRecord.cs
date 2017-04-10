namespace Aegis.Shp
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct PolygonRecord
    {
        public int ShapeType;
        public Box Box;
        public int NumParts;
        public int NumPoints;
        public int[] Parts;
        public Point[] Points;
    }
}
