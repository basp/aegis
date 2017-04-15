namespace Aegis.Sql
{
    using System;

    public class FieldDefinition : IFieldDefinition
    {
        public string Name => throw new NotImplementedException();

        public FieldType Type => throw new NotImplementedException();

        public int Width => throw new NotImplementedException();

        public int Precision => throw new NotImplementedException();
    }
}
