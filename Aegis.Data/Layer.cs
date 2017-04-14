namespace Aegis.Data
{
    public class Layer
    {
        public int Id
        {
            get;
            set;
        }

        public int FeatureTypeId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int StyleId
        {
            get;
            set;
        }

        public virtual Style Style
        {
            get;
            set;
        }
    }
}
