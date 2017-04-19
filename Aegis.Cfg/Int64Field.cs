namespace Aegis.Cfg
{
    public class Int64Field : Field
    {
        public override int Precision => -1;

        public override FieldType Type => FieldType.Int64;

        public override int Width => -1;
    }
}
