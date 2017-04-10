namespace Aegis
{
    public interface IFeatureDefinition
    {
        int FieldCount { get; }

        IFieldDefinition GetFieldDefinition(int index);
    }
}
