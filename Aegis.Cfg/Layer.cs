namespace Aegis.Cfg
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Layer : ILayer
    {
        private static class IndexNames
        {
            public const string DatasetLayer = "IX_DatasetId_LayerName";
        }

        private int fp = 0;

        public Layer()
        {
            this.Features = new List<Feature>();
            this.Fields = new List<Field>();
        }

        [Index(IndexNames.DatasetLayer, Order = 1, IsUnique = true)]
        public int DatasetId
        {
            get;
            set;
        }

        public virtual ICollection<Feature> Features
        {
            get;
            private set;
        }

        public virtual ICollection<Field> Fields
        {
            get;
            private set;
        }

        public int Id
        {
            get;
            private set;
        }

        [Index(IndexNames.DatasetLayer, Order = 2, IsUnique = true)]
        [MaxLength(32)]
        public string Name
        {
            get;
            set;
        }

        public virtual void CreateField(IFieldDefinition field)
        {
            throw new NotImplementedException();
        }

        public virtual void DeleteField(int index)
        {
            throw new NotImplementedException();
        }

        public virtual int GetFeatureCount(bool force = false) =>
            this.Features.Count;

        public virtual IFeatureDefinition GetLayerDefinition()
        {
            throw new NotImplementedException();
        }

        public virtual IFeature GetNextFeature()
        {
            if (this.fp == this.GetFeatureCount())
            {
                return null;
            }

            return this.Features.ElementAt(this.fp++);
        }

        public virtual void Reset()
        {
            this.fp = 0;
        }
    }
}
