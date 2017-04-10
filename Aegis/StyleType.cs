namespace Aegis
{
    public enum StyleType
    {
        /// <summary>
        /// An undefined or unknown style type.
        /// </summary>
        None = 0,

        /// <summary>
        /// A categorized style type.
        /// </summary>
        /// <remarks>
        /// Categorized styles are usally applied to textual data.
        /// </remarks>
        Categorized = 1,

        /// <summary>
        /// A graduated style type.
        /// </summary>
        /// <remarks>
        /// Graduated styles are usually applied to numeric data.
        /// </remarks>
        Graduated = 2,

        /// <summary>
        /// The system will perform a best effort just-in-time
        /// classification.
        /// </summary>
        /// <remarks>
        /// This uses a few simple heuristics to automatically find
        /// out how to best classify the data and perform the
        /// classification at runtime when the data is requested.
        /// </remarks>
        Dynamic = 3,
    }
}
