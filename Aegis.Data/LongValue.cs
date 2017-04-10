namespace Aegis.Data
{
    public class LongValue : FieldValue
    {
        public LongValue(int featureIndex, int fieldIndex, long x)
            : base(featureIndex, fieldIndex)
        {
            this.Long = x;
        }

        private LongValue()
        {
        }

        public long Long { get; private set; }
    }
}
