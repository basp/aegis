namespace Aegis.Shp
{
    using System;
    using System.IO;

    public class Driver : IDriver
    {
        private const string Extension = ".shp";

        /// <summary>
        /// Creates a new shapefile <see cref="IDriver"/> instance.
        /// </summary>
        /// <param name="path">The path to the shapefile's .shp file.</param>
        /// <returns>A shapefile <see cref="IDataset"/> instance.</returns>
        public IDataset Create(string path)
        {
            if (!HasValidExtension(path))
            {
                return null;
            }

            return Dataset.Create(path);
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
