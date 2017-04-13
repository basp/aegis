namespace Aegis.Sfa
{
    using Sprache;

    public static class WktParserExtensions
    {
        internal static Geometry Parse(this WktParser self, string text) =>
            self.Geometry().Parse(text);
    }
}
