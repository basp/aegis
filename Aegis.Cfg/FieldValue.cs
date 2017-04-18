namespace Aegis.Cfg
{
    public abstract class FieldValue
    {
        public int LayerId
        {
            get;
            set;
        }

        public int FeatureIndex
        {
            get;
            set;
        }

        public int FieldIndex
        {
            get;
            set;
        }

        public virtual Feature Feature
        {
            get;
            set;
        }
    }
}
