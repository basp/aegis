namespace Aegis.Data
{
    using System.Collections.Generic;

    public class Workspace
    {
        private Workspace()
        {
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

        public ICollection<FeatureType> FeatureTypes
        {
            get;
            set;
        }

        public static Workspace Create(string name)
        {
            return new Workspace
            {
                Name = name
            };
        }
    }
}
