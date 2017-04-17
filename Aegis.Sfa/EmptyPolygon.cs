namespace Aegis.Sfa
{
    public class EmptyPolygon : Polygon
    {
        public EmptyPolygon(int srid)
            : this(new EmptyLineString(srid), new LineString[0], srid)
        {
        }

        private EmptyPolygon(
            LineString exteriorRing,
            LineString[] interiorRings,
            int srid)
            : base(exteriorRing, interiorRings, srid)
        {
        }

        public override bool IsEmpty() => true;
    }
}