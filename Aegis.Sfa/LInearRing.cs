namespace Aegis.Sfa
{
    public class LinearRing : LineString
    {
        public LinearRing(Point[] points, int srid)
            : base(points, srid)
        {
        }

        public override bool IsClosed() => true;

        public override bool IsSimple() => true;
    }
}