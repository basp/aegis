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

        public bool TestCapabilities(DriverCapabilities capabilities) =>
            throw new NotImplementedException();

        private static bool HasValidExtension(string path)
        {
            return Path.GetExtension(path).Equals(
                Extension,
                StringComparison.OrdinalIgnoreCase);
        }
    }
}
