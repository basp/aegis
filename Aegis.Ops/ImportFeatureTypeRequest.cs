namespace Aegis.Ops
{
    public class ImportFeatureTypeRequest
    {
        public int WorkspaceId { get; set; }

        public string Name { get; set; }

        public IFeatureDefinition FeatureDefinition { get; set; }
    }
}
