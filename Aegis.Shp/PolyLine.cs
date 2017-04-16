namespace Aegis.Shp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Aegis.Sfa;

    public class PolyLine : IGeometry
    {
        internal PolyLine(
            Box box,
            int numParts,
            int numPoints,
            int[] parts,
            Point[] points)
        {
            this.BBox = box;
            this.NumParts = numParts;
            this.NumPoints = numPoints;
            this.Parts = parts;
            this.Points = points;
        }

        public Box BBox { get; }

        public int NumParts { get; }

        public int NumPoints { get; }

        public int[] Parts { get; }

        public Point[] Points { get; }

        public byte[] AsBinary() =>
            this.AsStandardGeometry().AsBinary();

        public string AsText() =>
            this.AsStandardGeometry().AsText();

        internal Geometry AsStandardGeometry()
        {
            var lineStrings = this.GetLineStrings().ToArray();
            if (lineStrings.Length == 0)
            {
                return lineStrings.First();
            }

            return new MultiLineString(lineStrings);
        }

        private IEnumerable<LineString> GetLineStrings()
        {
            var parts = this.Parts.GetParts(this.Points);
            return parts.Select(x => new LineString(x.ToArray()));
        }
    }
}
