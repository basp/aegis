namespace Aegis.Cfg
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Layer : ILayer
    {
        private int fp = 0;

        public Layer()
        {
            this.Features = new List<Feature>();
            this.Fields = new List<Field>();
        }

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
