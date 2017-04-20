namespace Aegis.Cfg
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Workspace
    {
        private static class IndexNames
        {
            public const string WorkspaceName = "IX_WorkspaceName";
        }

        public Workspace()
        {
            this.Datasets = new List<Dataset>();
        }

        public int Id
        {
            get;
            private set;
        }

        [Index(IsUnique = true)]
        [MaxLength(32)]
        public string Name
        {
            get;
            set;
        }

        public void AddDataset(Dataset dataset)
        {
            dataset.WorkspaceId = this.Id;
            this.Datasets.Add(dataset);
        }

        public virtual ICollection<Dataset> Datasets
        {
            get;
            private set;
        }
    }
}
