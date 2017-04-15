namespace Aegis.Shp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Polygon : IGeometry
    {
        private readonly Box box;
        private readonly int numParts;
        private readonly int numPoints;
        private readonly int[] parts;
        private readonly Point[] points;

        internal Polygon(
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

        public string AsText()
        {
            var rings = this.parts.GetParts(this.points)
                .Select(x => new ArraySegment<Point>(this.points, x.Item1, x.Item2))
                .ToArray();

            // Polygons may consist of multiple exterior rings. 

            throw new NotImplementedException();
        }
    }
}
