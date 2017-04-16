namespace Aegis.Sfa
{
    using System;
    using System.Linq;

    public class MultiLineString : MultiCurve
    {
        private readonly LineString[] lineStrings;

        public MultiLineString(LineString[] lineStrings, int srid)
            : base(lineStrings, srid)
        {
            this.lineStrings = lineStrings;
        }

        public MultiLineString(params LineString[] lineStrings)
            : this(lineStrings, 0)
        {
        }

        public override byte[] AsBinary()
        {
            throw new NotImplementedException();
        }

        public override string AsText() =>
            $"{nameof(MultiLineString).ToUpperInvariant()} {this.AsTextNoIdent()}";

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

        public override bool IsClosed()
        {
            throw new NotImplementedException();
        }

        public override bool IsSimple()
        {
            throw new NotImplementedException();
        }

        public override double Length()
        {
            throw new NotImplementedException();
        }

        internal string AsTextNoIdent()
        {
            var lineStringStrings = this.lineStrings
                .Select(x => x.AsTextNoIdent())
                .ToArray();

            return $"({string.Join(", ", lineStringStrings)})";
        }
    }
}
