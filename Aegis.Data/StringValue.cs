namespace Aegis.Data
{
    public class StringValue : FieldValue
    {
        public StringValue(int featureIndex, int fieldIndex, string v)
            : base(featureIndex, fieldIndex)
        {
            this.String = v;
        }

        private StringValue()
        {
        }

        public string String
        {
            get;
            private set;
        }
    }
}
