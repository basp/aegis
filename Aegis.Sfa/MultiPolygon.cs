namespace Aegis.Sfa
{
    using System;
    using System.Linq;

    public class MultiPolygon : MultiSurface
    {
        private readonly Polygon[] polygons;

        public MultiPolygon(Polygon[] polygons, int srid)
            : base(polygons, srid)
        {
            this.polygons = polygons;
        }

        public MultiPolygon(params Polygon[] polygons)
            : this(polygons, 0)
        {
        }

        public override byte[] AsBinary()
        {
            throw new NotImplementedException();
        }

        public override string AsText() =>
            $"{nameof(MultiPolygon).ToUpperInvariant()} {this.AsTextNoIdent()}";

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

        public override bool IsSimple()
        {
            throw new NotImplementedException();
        }

        internal string AsTextNoIdent()
        {
            var polyStrings = this.polygons
                .Select(x => x.AsTextNoIdent())
                .ToArray();

            return $"({string.Join(", ", polyStrings)})";
        }
    }
}
