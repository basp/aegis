namespace Aegis.Sfa
{
    using System;

    public class MultiPoint : GeometryCollection
    {
        public MultiPoint(Point[] points, int srid)
            : base(points, srid)
        {
        }

        public MultiPoint(params Point[] points)
            : this(points, 0)
        {
        }

        public override byte[] AsBinary()
        {
            throw new NotImplementedException();
        }

        public override string AsText()
        {
            throw new NotImplementedException();
        }

        public override Geometry Centroid()
        {
            throw new NotImplementedException();
        }

        public override bool Contains(Geometry other)
        {
            throw new NotImplementedException();
        }

        public override int Dimension() => 0;

        public override double Distance(Geometry other)
        {
            throw new NotImplementedException();
        }

        public override string GeometryType() => nameof(MultiPoint);

        public override bool IsSimple() => throw new NotImplementedException();
    }
}