namespace Aegis.Shp
{
    using System;

    public class MultiPoint : IGeometry
    {
        private readonly Box box;
        private readonly int numPoints;
        private readonly Point[] points;

        internal MultiPoint(
            Box box,
            int numPoints,
            Point[] points)
        {
            this.box = box;
            this.numPoints = numPoints;
            this.points = points;
        }

        public byte[] AsBinary() =>
            throw new NotImplementedException();

        public string AsText() =>
            $"MULTIPOINT {this.numPoints}";
    }
}