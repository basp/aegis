namespace Aegis.Shp
{
    public struct MultiPointRecord
    {
        public readonly int ShapeType;
        public readonly Box Box;
        public readonly int NumPoints;
        public readonly Point[] Points;

        public MultiPointRecord(
            int shapeType,
            Box box,
            int numPoints,
            Point[] points)
        {
            this.ShapeType = shapeType;
            this.Box = box;
            this.NumPoints = numPoints;
            this.Points = points;
        }
    }
}