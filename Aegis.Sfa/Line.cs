namespace Aegis.Sfa
{
    /// <summary>
    /// A <see cref="Line"/> is a <see cref="LineString"/> with exactly 2 
    /// <see cref="Point"/> instances.
    /// </summary>
    public class Line : LineString
    {
        public Line(Point a, Point b, int srid)
            : base(new[] { a, b }, srid)
        {
        }

        public override string GeometryType() => nameof(Line);
    }
}