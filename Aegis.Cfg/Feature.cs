namespace Aegis.Cfg
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Feature : IFeature
    {
        public Feature()
        {
            this.FieldValues = new List<FieldValue>();
        }

        public int LayerId
        {
            get;
            set;
        }

        public int Index
        {
            get;
            set;
        }

        public ICollection<FieldValue> FieldValues
        {
            get;
            private set;
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

        public string GetFieldAsString(int index) =>
            this.FieldValues.ElementAt(index).ToString();

        public IGeometry GetGeometry()
        {
            throw new NotImplementedException();
        }
    }
}
