﻿namespace Aegis.Data
{
    public class LongValue : FieldValue
    {
        public LongValue(int featureIndex, int fieldIndex, long v)
            : base(featureIndex, fieldIndex)
        {
            this.Long = v;
        }

        private LongValue()
        {
        }

        public long Long
        {
            get;
            private set;
        }
    }
}
