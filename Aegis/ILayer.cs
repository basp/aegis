namespace Aegis
{
    public interface ILayer
    {
        string Name { get; }

        void CreateField(IFieldDefinition field);

        void DeleteField(int index);

        /// <summary>
        /// Returns the number of features in the layer. If <paramref name="force"/> is
        /// <c>false</c> and it would be expensive to establish the feature count a
        /// value of -1 may be returned indicating that the count is unknown.
        /// </summary>
        /// <param name="force">
        /// If <c>true</c> some implementations will actually scan the entire once
        /// to count the number of features.
        /// </param>
        /// <returns>The number of features in the layer.</returns>
        int GetFeatureCount(bool force = false);

        IFeatureDefinition GetLayerDefinition();

        IFeature GetNextFeature();

        void Reset();
    }
}
