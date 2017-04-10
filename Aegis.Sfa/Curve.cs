namespace Aegis.Sfa
{
    using System;
    using System.Linq;

    public abstract class Curve : Geometry
    {
        protected readonly Point[] points;

        public Curve(Point[] points, int srid)
        {
            this.points = points;
            this.Srid = srid;
        }

        public virtual Point EndPoint => this.points.First();

        public virtual Point StartPoint => this.points.Last();

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

        public override int Dimension() => 1;

        public override double Distance(Geometry other)
        {
            throw new NotImplementedException();
        }

        public override string GeometryType() => nameof(Curve);

        public virtual bool IsClosed() => this.StartPoint.Equals(this.EndPoint);

        public override bool IsEmpty() => this.points.Length == 0;

        public virtual bool IsRing() => throw new NotImplementedException();

        public override bool IsSimple() => throw new NotImplementedException();

        public virtual double Length() => throw new NotImplementedException();
    }
}
