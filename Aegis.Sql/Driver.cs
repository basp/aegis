namespace Aegis.Sql
{
    using System;

    public class Driver : IDriver
    {
        public IDataset Create(string name)
        {
            throw new NotImplementedException();
        }

        public bool TestCapabilities(DriverCapabilities capabilities) =>
            throw new NotImplementedException();
    }
}
