namespace Aegis.Data
{
    public class DoubleValue : FieldValue
    {
        public DoubleValue(int featureIndex, int fieldIndex, double v)
            : base(featureIndex, fieldIndex)
        {
            this.Double = v;
        }

        private DoubleValue()
        {
        }

        public double Double { get; private set; }
    }
}
