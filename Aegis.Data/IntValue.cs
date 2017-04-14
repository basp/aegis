namespace Aegis.Data
{
    public class IntValue : FieldValue
    {
        protected IntValue(int featureIndex, int fieldIndex, int v)
            : base(featureIndex, fieldIndex)
        {
            this.Int = v;
        }

        private IntValue()
        {
        }

        public int Int
        {
            get;
            private set;
        }
    }
}
