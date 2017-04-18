namespace Aegis.Cfg
{
    public class DoubleField : Field
    {
        public override int Precision => -1;

        public override FieldType Type => FieldType.Double;

        public override int Width => -1;
    }
}
