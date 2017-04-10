namespace Aegis.Vis
{
    using System;

    public static class Extensions
    {
        public static T Clamp<T>(this T self, T min, T max)
            where T : IComparable
        {
            if (self.CompareTo(min) < 0)
            {
                return min;
            }

            if (self.CompareTo(max) > 0)
            {
                return max;
            }

            return self;
        }

        public static double Lerp(this double self, double other, double alpha)
        {
            return ((1.0 - alpha) * self) + (alpha * other);
        }

        public static Tuple<double, double, double> Lerp(
            this Tuple<double, double, double> self,
            Tuple<double, double, double> other,
            double alpha)
        {
            var r = self.Item1.Lerp(other.Item1, alpha);
            var g = self.Item2.Lerp(other.Item2, alpha);
            var b = self.Item3.Lerp(other.Item3, alpha);
            return Tuple.Create(r, g, b);
        }

        public static string ToHtmlColor(this Tuple<double, double, double> t)
        {
            var r = (short)Math.Round(t.Item1 * 255);
            var g = (short)Math.Round(t.Item2 * 255);
            var b = (short)Math.Round(t.Item3 * 255);
            return string.Format(
                "#{0}{1}{2}",
                r.ToString("X2"),
                g.ToString("X2"),
                b.ToString("X2"));
        }
    }
}
