namespace Aegis.Sfa
{
    using System;
    using System.Linq;

    public abstract class Curve : Geometry
    {
        private readonly Point[] points;

        public Curve(Point[] points, int srid)
        {
            this.points = points;
            this.EndPoint = points.Last();
            this.StartPoint = points.First();
            this.Srid = srid;
        }

        public virtual Point EndPoint { get; }

        public virtual Point StartPoint { get; }

        protected Point[] Points => this.points;

        public virtual bool IsClosed() => this.StartPoint.Equals(this.EndPoint);

        public virtual bool IsRing() => throw new NotImplementedException();

        public virtual double Length() => throw new NotImplementedException();
    }
}