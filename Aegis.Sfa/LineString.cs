﻿namespace Aegis.Sfa
{
    using System;
    using System.Linq;

    /// <summary>
    /// A LineString is a <see cref="Curve"/> with linear interpolation between
    /// <see cref="Point"/> instances. Each consecutive pair of <see cref="Point"/>
    /// instances defines a <see cref="Line"/> segment.
    /// </summary>
    public class LineString : Curve
    {
        public LineString(Point[] points, int srid)
            : base(points, srid)
        {
        }

        public override byte[] AsBinary()
        {
            throw new NotImplementedException();
        }

        public override string AsText()
        {
            return $"{nameof(Polygon).ToUpperInvariant()} {this.AsTextNoIdent()}";
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

        public override string GeometryType() => nameof(LineString);

        public override bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public override bool IsSimple() => throw new NotImplementedException();

        public virtual int NumPoints() => this.points.Length;

        public virtual Point PointN(int n) => this.points[n - 1];

        internal virtual string AsTextNoIdent()
        {
            var points = this.points
                .Select(p => p.AsTextNoIdentNoParens())
                .ToArray();

            return $"({string.Join(", ", points)})";
        }
    }
}