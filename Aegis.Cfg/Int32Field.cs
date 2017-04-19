namespace Aegis.Cfg
{
    public class Int32Field : Field
    {
        public override int Precision => -1;

        public override FieldType Type => FieldType.Int32;

        public override int Width => -1;
    }
}
