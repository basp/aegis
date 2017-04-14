namespace Aegis.Data
{
    using System.Collections.Generic;

    public class Style
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

        public int FieldIndex
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public StyleType StyleType
        {
            get;
            set;
        }

        public virtual ICollection<StyleClass> Classes
        {
            get;
            set;
        }
    }
}
