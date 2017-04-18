namespace Aegis.Cfg
{
    using System.Collections.Generic;

    public class Dataset
    {
        public Dataset()
        {
            this.Layers = new List<Layer>();
        }

        public int Id
        {
            get;
            private set;
        }

        public int WorkspaceId
        {
            get;
            set;
        }

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
    }
}
