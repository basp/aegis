namespace Aegis.Sfa
{
    using System;
    using System.Linq;

    public class Polygon : Surface
    {
        private readonly LineString exteriorRing;
        private readonly LineString[] interiorRings;

        public Polygon(LineString exteriorRing, LineString[] interiorRings, int srid)
        {
            this.Srid = srid;
            this.exteriorRing = exteriorRing;
            this.interiorRings = interiorRings;
        }

        public override byte[] AsBinary()
        {
            throw new NotImplementedException();
        }

        public override string AsText() =>
            $"{nameof(Polygon).ToUpperInvariant()} {this.AsTextNoIdent()}";

        public override Geometry Centroid()
        {
            throw new NotImplementedException();
        }

        public override bool Contains(Geometry other)
        {
            throw new NotImplementedException();
        }

        public override int Dimension()
        {
            throw new NotImplementedException();
        }

        public override double Distance(Geometry other)
        {
            throw new NotImplementedException();
        }

        public LineString ExteriorRing() => this.exteriorRing;

        public override string GeometryType()
        {
            throw new NotImplementedException();
        }

        public LineString InteriorRingN(int n) => this.interiorRings[n - 1];

        public override bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public override bool IsSimple()
        {
            throw new NotImplementedException();
        }

        public int NumInteriorRing() => this.interiorRings.Length;

        internal virtual string AsTextNoIdent()
        {
            var lineStrings = new[] { this.exteriorRing }
                .Concat(this.interiorRings)
                .Select(s => s.AsTextNoIdent())
                .ToArray();

            return $"({string.Join(", ", lineStrings)})";
        }
    }
}