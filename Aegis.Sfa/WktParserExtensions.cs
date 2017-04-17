namespace Aegis.Sfa
{
    using Sprache;

    public static class WktParserExtensions
    {
        // Probobaly should drop this in favor of a WktReader class.
        internal static Geometry Parse(this WktParser self, string text) =>
            self.Geometry().Parse(text);
    }
}