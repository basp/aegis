namespace Aegis.Sql
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Dataset : IDataset
    {
        private readonly string connectionString;

        private Dataset(string connectionString)
        {
            this.connectionString = connectionString;
            this.Layers = new List<Layer>();
        }

        public virtual ICollection<Layer> Layers
        {
            get;
            private set;
        }

        public string Name => this.connectionString;

        public ILayer CreateLayer(string name) =>
            throw new NotImplementedException();

        public ILayer GetLayer(int index) =>
            this.Layers.ElementAt(index);

        public ILayer GetLayerByName(string name) =>
            this.Layers.FirstOrDefault(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

        public int GetLayerCount() => this.Layers.Count;
    }
}
