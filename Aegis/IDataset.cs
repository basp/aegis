namespace Aegis
{
    public interface IDataset
    {
        string Name { get; }

        ILayer CreateLayer(string name);

        int GetLayerCount();

        ILayer GetLayer(int index);

        ILayer GetLayerByName(string name);
    }
}
