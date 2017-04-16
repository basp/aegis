namespace Aegis.Sfa
{
    public class LinearRing : LineString
    {
        public LinearRing(Point[] points, int srid)
            : base(points, srid)
        {
        }

        public LinearRing(params Point[] points)
            : this(points, 0)
        {
        }

        public override bool IsSimple() => true;
    }
}