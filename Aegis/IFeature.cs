namespace Aegis
{
    public interface IFeature
    {
        int GetFieldAsInt(int index);

        long GetFieldAsInt64(int index);

        double GetFieldAsDouble(int index);

        string GetFieldAsString(int index);

        IGeometry GetGeometry();
    }
}
