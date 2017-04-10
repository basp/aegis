namespace Aegis
{
    public interface ILayer
    {
        string Name { get; }

        IFeatureDefinition GetLayerDefinition();

        IFeature GetNextFeature();

        void Reset();
    }
}
