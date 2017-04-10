namespace Aegis
{
    public interface IDataset
    {
        ILayer CreateLayer(string name);

        int GetLayerCount();

        ILayer GetLayer(int index);

        ILayer GetLayerByName(string name);
    }
}
