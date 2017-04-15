namespace Aegis.Sql
{
    using System;

    public class Layer : ILayer
    {
        public string Name => throw new NotImplementedException();

        public void CreateField(IFieldDefinition field)
        {
            throw new NotImplementedException();
        }

        public void DeleteField(int index)
        {
            throw new NotImplementedException();
        }

        public int GetFeatureCount(bool force = false)
        {
            throw new NotImplementedException();
        }

        public IFeatureDefinition GetLayerDefinition()
        {
            throw new NotImplementedException();
        }

        public IFeature GetNextFeature()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
