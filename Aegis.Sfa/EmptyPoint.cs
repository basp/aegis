namespace Aegis.Sfa
{
    public class EmptyPoint : Point
    {
        public EmptyPoint(int srid)
            : this(0, 0, srid)
        {
        }

        private EmptyPoint(double x, double y, int srid)
            : base(x, y, srid)
        {
        }

        public override bool IsEmpty() => true;
    }
}