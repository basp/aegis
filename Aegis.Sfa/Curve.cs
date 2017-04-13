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

        public virtual bool IsClosed() => this.StartPoint.Equals(this.EndPoint);

        public virtual bool IsRing() => throw new NotImplementedException();

        public virtual double Length() => throw new NotImplementedException();
    }
}
