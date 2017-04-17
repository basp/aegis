namespace Aegis
{
    using System;

    [Flags]
    public enum DriverCapabilities
    {
        /// <summary>
        /// The driver has no or unknown capabilities.
        /// </summary>
        None = 0,

        /// <summary>
        /// The driver supports creating fields.
        /// </summary>
        CreateField = 1,

        /// <summary>
        /// The driver supports deleting fields.
        /// </summary>
        DeleteField = 2,

        /// <summary>
        /// The driver supports requesting the feature count
        /// in an efficient way (without scanning the dataset).
        /// </summary>
        FastFeatureCount = 4,
    }
}
