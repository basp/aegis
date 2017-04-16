namespace Aegis.Shp
{
    using System.Collections.Generic;
    using System.Linq;
    using Aegis.Sfa;

    public class Polygon : IGeometry
    {
        internal Polygon(
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

        public override string ToString() =>
            $"Type = {nameof(Polygon)}, NumParts = {this.NumParts}";

        internal Geometry AsStandardGeometry()
        {
            var polygons = this.GetPolygons().ToArray();
            if (polygons.Length == 1)
            {
                return polygons.First();
            }

            // If we have multiple exterior rings then we are dealing
            // with (what is nowadays known as) a **MultiPolygon**.
            return new MultiPolygon(polygons);
        }

        private IEnumerable<Sfa.Polygon> GetPolygons()
        {
            LineString exterior = null;
            IList<LineString> interior = new List<LineString>();

            var parts = this.Parts.GetParts(this.Points);
            exterior = new LineString(parts.First().ToArray());
            foreach (var part in parts.Skip(1))
            {
                var points = part.ToArray();

                // The *shoelace* check will fail on polygons that are not *simple*
                // but at least it works for both concave and convex simple polygons.
                // If the value (which represents an area) of the shoelace check is
                // below zero we can consider the order of the vertices in the polygon
                // as being in a CCW fashion. If it's zero or above we consider it to
                // be CW.
                var cw = points.Shoelace() >= 0;

                // So if it's clockwise, according to the spec, it **must** be an
                // exterior ring of a polygon. Interior rings have a CCW order.
                if (cw)
                {
                    yield return new Sfa.Polygon(exterior, interior.ToArray());
                    exterior = new LineString(part.ToArray());
                    continue;
                }

                // If it's not an exterior ring it has to be an interior ring so
                // we'll just store it in the interior ring buffer and return this
                // the next time we find another exterior ring...
                interior.Add(new LineString(part.ToArray()));
            }

            // And we'll have to return trailing results as well of course.
            yield return new Sfa.Polygon(exterior, interior.ToArray());
        }
    }
}
