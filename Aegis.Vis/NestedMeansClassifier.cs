﻿namespace Aegis.Vis
{
    using System.Collections.Generic;
    using System.Linq;
    using MathNet.Numerics.Statistics;

    public class NestedMeansClassifier : IClassifier<double>
    {
        private readonly int depth;

        public NestedMeansClassifier(int depth = 2)
        {
            this.depth = depth;
        }

        public IEnumerable<IStyleClass> Classify(IEnumerable<double> data)
        {
            return Classify(data, this.depth)
                .Where(x => x.Any())
                .Select(x => CreateRecord(x));
        }

        private static IStyleClass CreateRecord(IEnumerable<double> bucket)
        {
            var min = bucket.Min();
            var max = bucket.Max();
            var legend = $"{min} - {max}";
            return new GraduatedStyleClass(legend)
            {
                Min = min,
                Max = max,
            };
        }

        private static IEnumerable<IEnumerable<double>> Classify(
            IEnumerable<double> data,
            int depth)
        {
            if (depth == 0)
            {
                return new List<IEnumerable<double>>(new[] { data });
            }

            var mean = Statistics.Mean(data);
            var lo = Classify(data.Where(x => x < mean), depth - 1);
            var hi = Classify(data.Where(x => x >= mean), depth - 1);
            return lo.Concat(hi);
        }
    }
}
