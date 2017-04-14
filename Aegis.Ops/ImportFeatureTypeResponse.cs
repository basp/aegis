namespace Aegis.Ops
{
    using Aegis.Data;

    public class ImportFeatureTypeResponse
    {
        public ImportFeatureTypeResponse(FeatureType featureType)
        {
            this.FeatureType = featureType;
        }

        public FeatureType FeatureType { get; }
    }
}
