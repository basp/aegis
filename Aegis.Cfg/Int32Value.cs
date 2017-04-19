namespace Aegis.Cfg
{
    using System.Globalization;

    public class Int32Value : FieldValue
    {
        public int Int32 { get; }

        public override string ToString()
        {
            return this.Int32.ToString(CultureInfo.InvariantCulture);
        }
    }
}
