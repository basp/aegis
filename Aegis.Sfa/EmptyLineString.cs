namespace Aegis.Sfa
{
    using System.IO;

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
    }
}