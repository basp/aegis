namespace Aegis.Shp
{
    using System;
    using System.IO;

    public class Driver : IDriver
    {
        private const string Extension = ".shp";

        public IDataset Create(string name)
        {
            if (!HasValidExtension(name))
            {
                return null;
            }

            return Dataset.Create(name);
        }

        private static bool HasValidExtension(string path)
        {
            return Path.GetExtension(path).Equals(
                Extension,
                StringComparison.OrdinalIgnoreCase);
        }
    }
}
