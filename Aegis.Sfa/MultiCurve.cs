namespace Aegis.Sfa
{
    public abstract class MultiCurve : GeometryCollection
    {
        public MultiCurve(Geometry[] geometries, int srid)
            : base(geometries, srid)
        {
        }

        public abstract bool IsClosed();

        public abstract double Length();
    }
}
