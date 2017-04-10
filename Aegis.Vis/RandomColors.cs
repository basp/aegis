namespace Aegis.Vis
{
    using System;

    public class RandomColors : IColorRamp
    {
        private static readonly Random Rng = new Random();

        public static Tuple<double, double, double> GetRandomColor()
        {
            var r = Rng.NextDouble();
            var g = Rng.NextDouble();
            var b = Rng.NextDouble();
            return Tuple.Create(r, g, b);
        }

        public Tuple<double, double, double> GetColor(double n)
        {
            return GetRandomColor();
        }
    }
}
