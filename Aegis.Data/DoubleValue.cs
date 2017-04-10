namespace Aegis.Data
{
    public class DoubleValue : FieldValue
    {
        public DoubleValue(int featureIndex, int fieldIndex, double x)
            : base(featureIndex, fieldIndex)
        {
            this.Double = x;
        }

        private DoubleValue()
        {
        }

        public double Double { get; private set; }
    }
}
