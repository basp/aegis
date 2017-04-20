namespace Aegis.Cfg
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Dataset : IDataset
    {
        private static class IndexNames
        {
            public const string WorkspaceDataset = "IX_WorkspaceId_DatasetName";
        }

        public Dataset()
        {
            this.Layers = new List<Layer>();
        }

        public int Id
        {
            get;
            private set;
        }

        [Index(IndexNames.WorkspaceDataset, Order = 1, IsUnique = true)]
        public int WorkspaceId
        {
            get;
            set;
        }

        [Index(IndexNames.WorkspaceDataset, Order = 2, IsUnique = true)]
        [MaxLength(32)]
        public string Name
        {
            get;
            set;
        }

        public virtual ICollection<Layer> Layers
        {
            get;
            private set;
        }

        public ILayer CreateLayer(string name)
        {
            throw new NotImplementedException();
        }

        public int GetLayerCount() =>
            this.Layers.Count;

        public ILayer GetLayer(int index) =>
            this.Layers.ElementAt(index);

        public ILayer GetLayerByName(string name) =>
            this.Layers.FirstOrDefault(
                x => x.Name.Equals(
                    name,
                    StringComparison.InvariantCultureIgnoreCase));
    }
}
