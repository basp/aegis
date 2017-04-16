namespace Aegis.Sfa
{
    public abstract class MultiSurface : GeometryCollection
    {
        public MultiSurface(Geometry[] geometries, int srid)
            : base(geometries, srid)
        {
        }
    }
}
