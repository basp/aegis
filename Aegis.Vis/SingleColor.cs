namespace Aegis.Vis
{
    using System;

    public class SingleColor : IColorRamp
    {
        private readonly Tuple<double, double, double> color;

        public SingleColor()
            : this(RandomColors.GetRandomColor())
        {
        }

        public SingleColor(Tuple<double, double, double> color)
        {
            this.color = color;
        }

        public Tuple<double, double, double> GetColor(double n)
        {
            return this.color;
        }
    }
}
