namespace Aegis.Cfg
{
    using System.Collections.Generic;

    public class Workspace
    {
        public Workspace()
        {
            this.Datasets = new List<Dataset>();
        }

        public int Id
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            set;
        }

        public virtual ICollection<Dataset> Datasets
        {
            get;
            private set;
        }
    }
}
