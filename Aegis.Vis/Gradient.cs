namespace Aegis.Vis
{
    using System;
    using System.Collections.Generic;

    public class Gradient : IColorRamp
    {
        private readonly IList<GradientPoint> points =
            new List<GradientPoint>();

        public Tuple<double, double, double> GetColor(double n)
        {
            int indexPos;
            for (indexPos = 0; indexPos < this.points.Count; indexPos++)
            {
                if (n < this.points[indexPos].Position)
                {
                    break;
                }
            }

            var i0 = (indexPos - 1).Clamp(0, this.points.Count - 1);
            var i1 = (indexPos - 0).Clamp(0, this.points.Count - 1);

            if (i0 == i1)
            {
                return this.points[i0].Color;
            }

            var inp0 = this.points[i0].Position;
            var inp1 = this.points[i1].Position;
            var alpha = (n - inp0) / (inp1 - inp0);

            var c0 = this.points[i0].Color;
            var c1 = this.points[i1].Color;
            return c0.Lerp(c1, alpha);
        }

        public void AddPoint(GradientPoint point)
        {
            var pos = this.FindInsertPos(point.Position);
            this.InsertAtPos(pos, point.Position, point.Color);
        }

        /// <summary>
        /// Returns the insertion index for the new n-value. In other words,
        /// the index of the first value that is greater than specified n-value.
        /// </summary>
        /// <param name="n">The n-value to insert.</param>
        /// <returns>The insertion index of the specified n-value.</returns>
        private int FindInsertPos(double n)
        {
            int insertPos;
            for (insertPos = 0; insertPos < this.points.Count; insertPos++)
            {
                if (n < this.points[insertPos].Position)
                {
                    break;
                }

                if (n == this.points[insertPos].Position)
                {
                    throw new ArgumentException();
                }
            }

            return insertPos;
        }

        private void InsertAtPos(int i, double n, Tuple<double, double, double> color)
        {
            this.points.Insert(i, new GradientPoint(n, color));
        }
    }
}
