namespace Aegis.Sql
{
    using System;

    public class Driver : IDriver
    {
        /// <summary>
        /// Creates a new SQL <see cref="IDriver"/> instance.
        /// </summary>
        /// <param name="nameOrConnectionString">
        /// A connection string or a named connection string from a
        /// configuration file.
        /// </param>
        /// <returns>A new SQL <see cref="IDriver"/> instance.</returns>
        public IDataset Create(string nameOrConnectionString)
        {
            throw new NotImplementedException();
        }

        public bool TestCapabilities(DriverCapabilities capabilities) =>
            throw new NotImplementedException();
    }
}
