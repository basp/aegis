namespace Aegis.Sql
{
    using System;

    public class Dataset : IDataset
    {
        public ILayer CreateLayer(string name)
        {
            throw new NotImplementedException();
        }

        public ILayer GetLayer(int index)
        {
            throw new NotImplementedException();
        }

        public ILayer GetLayerByName(string name)
        {
            throw new NotImplementedException();
        }

        public int GetLayerCount()
        {
            throw new NotImplementedException();
        }
    }
}
