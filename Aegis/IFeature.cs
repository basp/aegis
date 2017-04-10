namespace Aegis
{
    public interface IFeature
    {
        int GetFieldAsInt(int index, int @default = default(int));

        long GetFieldAsInt64(int index, long @default = default(long));

        double GetFieldAsDouble(int index, double @default = default(double));

        string GetFieldAsString(int index);

        IGeometry GetGeometry();
    }
}
