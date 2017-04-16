namespace Aegis.Sfa
{
    public abstract class Surface : Geometry
    {
        protected Surface(int srid)
        {
            this.Srid = srid;
        }

        public abstract double Area();

        public abstract Point PointOnSurface();
    }
}