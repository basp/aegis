namespace Aegis.Sfa
{
    public class EmptyLineString : LineString
    {
        public EmptyLineString(int srid)
            : this(new Point[0], srid)
        {
        }

        private EmptyLineString(Point[] points, int srid)
            : base(points, srid)
        {
        }

        public override bool IsEmpty() => true;

        public override string AsText() =>
            $"{nameof(LineString).ToUpperInvariant()} EMPTY";
    }
}
