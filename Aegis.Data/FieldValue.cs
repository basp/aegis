namespace Aegis.Data
{
    using System;

    public abstract class FieldValue
    {
        protected FieldValue()
        {
        }

        protected FieldValue(int featureIndex, int fieldIndex)
        {
            this.FeatureIndex = featureIndex;
            this.FieldIndex = fieldIndex;
        }

        public int DatasetId
        {
            get;
            set;
        }

        public int FeatureIndex
        {
            get;
            set;
        }

        public int FieldIndex
        {
            get;
            set;
        }

        public object GetValue()
        {
            switch (this)
            {
                case StringValue x: return x.String;
                case DoubleValue x: return x.Double;
                case LongValue x: return x.Long;
                default: throw new ArgumentException();
            }
        }
    }
}
