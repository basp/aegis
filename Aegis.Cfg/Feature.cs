namespace Aegis.Cfg
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public class Feature : IFeature
    {
        public Feature()
        {
            this.FieldValues = new List<FieldValue>();
        }

        [Key]
        [Column(Order = 1)]
        public int Index
        {
            get;
            set;
        }

        [Key]
        [Column(Order = 2)]
        public int LayerId
        {
            get;
            set;
        }

        internal virtual ICollection<FieldValue> FieldValues
        {
            get;
            private set;
        }

        protected virtual DbGeometry Geometry
        {
            get;
            private set;
        }

        public virtual double GetFieldAsDouble(int index)
        {
            var v = (DoubleValue)this.FieldValues.ElementAt(index);
            return v.Double;
        }

        public virtual int GetFieldAsInt(int index)
        {
            var v = (Int32Value)this.FieldValues.ElementAt(index);
            return v.Int32;
        }

        public virtual long GetFieldAsInt64(int index)
        {
            var v = (Int64Value)this.FieldValues.ElementAt(index);
            return v.Int64;
        }

        public virtual string GetFieldAsString(int index) =>
            this.FieldValues.ElementAt(index).ToString();

        public virtual IGeometry GetGeometry()
        {
            return new GeometryAdapter(this.Geometry);
        }
    }
}
