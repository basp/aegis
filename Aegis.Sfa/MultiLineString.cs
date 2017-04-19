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
    }
}
