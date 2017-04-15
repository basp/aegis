namespace Aegis
{
    public interface IDriver
    {
        IDataset Create(string name);

        bool TestCapabilities(DriverCapabilities capabilities);
    }
}
