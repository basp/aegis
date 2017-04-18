namespace Aegis.Sql
{
    using System;

    public class FeatureDefinition : IFeatureDefinition
    {
        public int Id { get; private set; }

        public int WorkspaceId { get; set; }

        public int FieldCount => throw new NotImplementedException();

        public IFieldDefinition GetFieldDefinition(int index)
        {
            throw new NotImplementedException();
        }
    }
}
