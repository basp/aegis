namespace Aegis.Vis
{
    using System;

    public class GradientPoint
    {
        public GradientPoint(
            double position,
            Tuple<double, double, double> color)
        {
            this.Position = position;
            this.Color = color;
        }

        public double Position { get; }

        public Tuple<double, double, double> Color { get; }
    }
}
