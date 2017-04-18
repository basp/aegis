namespace Aegis.Cfg
{
    using System.Globalization;

    public class LongValue : FieldValue
    {
        public LongValue(long value)
        {
            this.Long = value;
        }

        private LongValue()
        {
        }

        public long Long
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return this.Long.ToString(CultureInfo.InvariantCulture);
        }
    }
}
