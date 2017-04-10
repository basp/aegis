namespace Aegis.Data
{
    public class StringValue : FieldValue
    {
        public StringValue(int featureIndex, int fieldIndex, string x)
            : base(featureIndex, fieldIndex)
        {
            this.String = x;
        }

        private StringValue()
        {
        }

        public string String { get; private set; }
    }
}
