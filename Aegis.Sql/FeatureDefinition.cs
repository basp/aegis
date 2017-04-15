namespace Aegis.Sql
{
    using System;

    public class FeatureDefinition : IFeatureDefinition
    {
        public int FieldCount => throw new NotImplementedException();

        public IFieldDefinition GetFieldDefinition(int index)
        {
            throw new NotImplementedException();
        }
    }
}
