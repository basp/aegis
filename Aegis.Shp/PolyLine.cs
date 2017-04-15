namespace Aegis.Shp
{
    using System;
    using System.Linq;

    public class PolyLine : IGeometry
    {
        private readonly Box box;
        private readonly int numParts;
        private readonly int numPoints;
        private readonly int[] parts;
        private readonly Point[] points;

        internal PolyLine(
            Box box,
            int numParts,
            int numPoints,
            int[] parts,
            Point[] points)
        {
            this.box = box;
            this.numParts = numParts;
            this.numPoints = numPoints;
            this.parts = parts;
            this.points = points;
        }

        public byte[] AsBinary() =>
            throw new NotImplementedException();

        public string AsText() =>
            $"POLYLINE {this.numParts} {this.numPoints} {string.Join(", ", this.parts)}";

        internal string AsTextNoIdent()
        {
            var ps = this.parts.GetParts(this.points);
            throw new NotImplementedException();
        }

        private string AsLineString()
        {
            throw new NotImplementedException();
        }
    }
}
