namespace Aegis.Cfg
{
    using System.Globalization;

    public class Int64Value : FieldValue
    {
        public Int64Value(long value)
        {
            this.Int64 = value;
        }

        private Int64Value()
        {
        }

        public long Int64
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return this.Int64.ToString(CultureInfo.InvariantCulture);
        }
    }
}
