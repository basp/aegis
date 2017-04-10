﻿namespace Aegis.Sfa
{
    using System;

    public class Point : Geometry
    {
        public Point(double x, double y, int srid)
        {
            this.X = x;
            this.Y = y;
            this.Srid = srid;
        }

        public double X { get; }

        public double Y { get; }

        public override byte[] AsBinary()
        {
            throw new NotImplementedException();
        }

        public override string AsText()
        {
            throw new NotImplementedException();
        }

        public override Geometry Centroid() => this;

        public override bool Contains(Geometry other) => false;

        public override int Dimension() => 0;

        public override double Distance(Geometry other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Point;
            if (other == null)
            {
                return false;
            }

            if (other.X != this.X)
            {
                return false;
            }

            if (other.Y != this.Y)
            {
                return false;
            }

            if (other.Srid != this.Srid)
            {
                return false;
            }

            return true;
        }

        public override string GeometryType() => nameof(Point);

        public override int GetHashCode()
        {
            return this.X.GetHashCode() + (31 * this.Y.GetHashCode());
        }

        public override bool IsEmpty() => false;

        public override bool IsSimple() => true;
    }
}
