namespace Aegis.Shp
{
    using Aegis.Sfa;

    public class MultiPoint : Sfa.MultiPoint
    {
        internal MultiPoint(
            Box box,
            int numPoints,
            Point[] points)
            : base(points)
        {
            this.BBox = box;
            this.NumPoints = numPoints;
            this.Points = points;
        }

        public Box BBox { get; }

        public int NumPoints { get; }

        public Point[] Points { get; }
    }
}