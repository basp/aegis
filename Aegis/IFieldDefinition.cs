namespace Aegis
{
    public interface IFieldDefinition
    {
        string Name { get; }

        FieldType Type { get; }

        int Width { get; }

        int Precision { get; }
    }
}