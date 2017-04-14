namespace Aegis.Data
{
    using System;

    public class GeometryAdapter : IGeometry
    {
        private readonly string text;

        public GeometryAdapter(string text)
        {
            this.text = text;
        }

        public string AsText()
        {
            return this.text;
        }
    }
}
