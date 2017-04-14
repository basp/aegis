namespace Aegis.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Dataset
    {
        private Dataset()
        {
            this.PropertyValues = new List<FieldValue>();
            this.Features = new List<Feature>();
        }

        private Dataset(
            int workspaceId,
            int featureTypeId,
            string name,
            int srid,
            DateTime dateCreated)
            : this()
        {
            this.WorkspaceId = workspaceId;
            this.FeatureTypeId = featureTypeId;
            this.Name = name;
            this.Srid = srid;
            this.DateCreated = dateCreated;
        }

        public DateTime DateCreated
        {
            get;
            set;
        }

        public virtual ICollection<Feature> Features
        {
            get;
            set;
        }

        public virtual FeatureType FeatureType
        {
            get;
            private set;
        }

        public int FeatureTypeId
        {
            get;
            set;
        }

        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public virtual ICollection<FieldValue> PropertyValues
        {
            get;
            set;
        }

        public int Srid
        {
            get;
            set;
        }

        public int WorkspaceId
        {
            get;
            set;
        }

        public static Dataset Create(
            int workspaceId,
            int featureTypeId,
            string name,
            int srid)
        {
            return new Dataset(
                workspaceId,
                featureTypeId,
                name,
                srid,
                DateTime.UtcNow);
        }

        public virtual DataTable GetDataTable()
        {
            throw new NotImplementedException();
        }
    }
}
