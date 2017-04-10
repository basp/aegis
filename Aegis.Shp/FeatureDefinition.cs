namespace Aegis.Shp
{
    using Aegis.Dbf;

    public class FeatureDefinition : IFeatureDefinition
    {
        private readonly FieldDescriptor[] fieldDescriptors;

        public FeatureDefinition(FieldDescriptor[] fieldDescriptors)
        {
            this.fieldDescriptors = fieldDescriptors;
        }

        public int FieldCount => this.fieldDescriptors.Length;

        public IFieldDefinition GetFieldDefinition(int index)
        {
            return new FieldDefinition(this.fieldDescriptors[index]);
        }
    }
}
