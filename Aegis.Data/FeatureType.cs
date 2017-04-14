namespace Aegis.Data
{
    using System.Collections.Generic;

    public class FeatureType
    {
        public FeatureType()
        {
            this.Fields = new List<Field>();
            this.DataSets = new List<Dataset>();
        }

        public int Id
        {
            get;
            set;
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

        public virtual ICollection<Field> Fields
        {
            get;
            set;
        }

        public virtual ICollection<Dataset> DataSets
        {
            get;
            set;
        }
    }
}
