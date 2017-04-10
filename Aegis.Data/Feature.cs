namespace Aegis.Data
{
    using System.Data.Entity.Spatial;

    public class Feature
    {
        private Feature()
        {
        }

        private Feature(
            int index,
            string wkt,
            DbGeometry geometry,
            int srs)
        {
            this.Index = index;
            this.WellKnownText = wkt;
            this.Geometry = geometry;
        }

        public int DatasetId { get; private set; }

        public int Index { get; private set; }

        public string WellKnownText { get; private set; }

        public virtual DbGeometry Geometry
        {
            get;
            private set;
        }

        public static Feature Create(
            int index,
            string wkt,
            int srs)
        {
            var geometry = DbGeometry.FromText(wkt, srs);
            return new Feature(index, wkt, geometry, srs);
        }
    }
}
