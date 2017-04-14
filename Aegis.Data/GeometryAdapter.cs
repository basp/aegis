namespace Aegis.Data
{
    using System;

    public class GeometryAdapter : IGeometry
    {
        private readonly string text;
        private readonly byte[] bytes;

        public GeometryAdapter(string text, byte[] bytes)
        {
            this.text = text;
            this.bytes = bytes;
        }

        public string AsText() => this.text;

        public byte[] AsBinary() => this.bytes;
    }
}
