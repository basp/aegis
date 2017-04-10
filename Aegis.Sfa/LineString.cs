namespace Aegis.Sfa
{
    using System;

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

        public override string GeometryType() => nameof(LineString);

        public override bool IsSimple() => throw new NotImplementedException();

        public virtual int NumPoints() => throw new NotImplementedException();

        public virtual Point PointN(int n) => throw new NotImplementedException();
    }
}
