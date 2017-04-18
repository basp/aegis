namespace Aegis.Cfg
{
    public abstract class Field : IFieldDefinition
    {
        public int LayerId
        {
            get;
            set;
        }

        public int Index
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public abstract int Precision
        {
            get;
        }

        public abstract FieldType Type
        {
            get;
        }

        public abstract int Width
        {
            get;
        }
    }
}
