namespace Aegis
{
    using System;

    [Flags]
    public enum DriverCapabilities
    {
        None = 0,
        CreateField = 1,
        DeleteField = 2,
        FastFeatureCount = 4,
    }
}
