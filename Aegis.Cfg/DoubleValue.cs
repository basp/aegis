namespace Aegis.Cfg
{
    using System.Globalization;

    public class DoubleValue : FieldValue
    {
        public DoubleValue(double value)
        {
            this.Double = value;
        }

        private DoubleValue()
        {
        }

        public double Double
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return this.Double.ToString(CultureInfo.InvariantCulture);
        }
    }
}
