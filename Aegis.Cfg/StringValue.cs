namespace Aegis.Cfg
{
    public class StringValue : FieldValue
    {
        public StringValue(string value)
        {
            this.String = value;
        }

        private StringValue()
        {
        }

        public string String
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return this.String;
        }
    }
}
