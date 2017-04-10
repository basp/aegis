namespace Aegis.Shp
{
    using System;
    using Aegis.Dbf;

    public class FieldDefinition : IFieldDefinition
    {
        private readonly FieldDescriptor fieldDescriptor;

        public FieldDefinition(FieldDescriptor fieldDescriptor)
        {
            this.fieldDescriptor = fieldDescriptor;
        }

        public string Name => this.fieldDescriptor.FieldName;

        public Aegis.FieldType Type
        {
            get
            {
                switch (this.fieldDescriptor.FieldType)
                {
                    case FieldType.Character: return Aegis.FieldType.String;
                    case FieldType.Numeric:
                        return this.fieldDescriptor.DecimalCount == 0
                            ? Aegis.FieldType.Long
                            : Aegis.FieldType.Double;
                    default: throw new ArgumentException();
                }
            }
        }

        public int Width => this.fieldDescriptor.FieldLength;

        public int Precision => this.fieldDescriptor.DecimalCount;
    }
}
