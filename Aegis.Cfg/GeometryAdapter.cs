namespace Aegis.Cfg
{
    using System.Data.Entity.Spatial;

    public class GeometryAdapter : IGeometry
    {
        private readonly DbGeometry geometry;

        public GeometryAdapter(DbGeometry geometry)
        {
            this.geometry = geometry;
        }

        public virtual byte[] AsBinary()
        {
            return this.geometry.AsBinary();
        }

        public virtual string AsText()
        {
            return this.geometry.AsText();
        }
    }
}
