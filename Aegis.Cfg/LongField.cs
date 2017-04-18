namespace Aegis.Cfg
{
    public class LongField : Field
    {
        public override int Precision => -1;

        public override FieldType Type => FieldType.Long;

        public override int Width => -1;
    }
}
