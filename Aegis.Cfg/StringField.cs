namespace Aegis.Cfg
{
    public class StringField : Field
    {
        public override int Precision => -1;

        public override FieldType Type => FieldType.String;

        public override int Width => -1;
    }
}
