namespace Aegis.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public class Feature : IFeature
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
            this.FieldValues = new List<FieldValue>();
        }

        public int DatasetId { get; private set; }

        public int Index { get; private set; }

        public string WellKnownText { get; private set; }

        public virtual DbGeometry Geometry
        {
            get;
            private set;
        }

        public virtual ICollection<FieldValue> FieldValues
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

        public double GetFieldAsDouble(int index)
        {
            var v = (DoubleValue)this.FieldValues.ElementAt(index);
            return v.Double;
        }

        public int GetFieldAsInt(int index)
        {
            throw new NotImplementedException();
        }

        public long GetFieldAsInt64(int index)
        {
            var v = (LongValue)this.FieldValues.ElementAt(index);
            return v.Long;
        }

        public string GetFieldAsString(int index)
        {
            var v = (StringValue)this.FieldValues.ElementAt(index);
            return v.String;
        }

        public IGeometry GetGeometry()
        {
            return new GeometryAdapter(this.Geometry.AsText());
        }
    }
}
