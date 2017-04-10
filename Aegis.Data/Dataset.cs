namespace Aegis.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Aegis.Data;

    public class Dataset
    {
        private Dataset()
        {
            this.PropertyValues = new List<FieldValue>();
            this.Features = new List<Feature>();
        }

        private Dataset(int featureTypeId, string name, int srs, DateTime dateCreated)
            : this()
        {
            this.FeatureTypeId = featureTypeId;
            this.Name = name;
            this.Srs = srs;
            this.DateCreated = dateCreated;
        }

        public int Id { get; set; }

        public int FeatureTypeId { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public int Srs { get; set; }

        public virtual FeatureType FeatureType { get; private set; }

        public virtual ICollection<Feature> Features { get; set; }

        public virtual ICollection<FieldValue> PropertyValues { get; set; }

        public virtual DataTable DataTable { get; private set; }

        public static Dataset Create(int featureTypeId, string name, int srs)
        {
            return new Dataset(
                featureTypeId,
                name,
                srs,
                DateTime.UtcNow);
        }
    }
}
