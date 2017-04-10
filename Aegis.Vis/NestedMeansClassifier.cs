namespace Aegis.Vis
{
    using System.Collections.Generic;
    using System.Linq;
    using Aegis.Data;
    using MathNet.Numerics.Statistics;

    public class NestedMeansClassifier : IClassifier<double>
    {
        private readonly int depth;

        public NestedMeansClassifier(int depth = 2)
        {
            this.depth = depth;
        }

        public IEnumerable<StyleClass> Classify(IEnumerable<double> data)
        {
            return Classify(data, this.depth)
                .Where(x => x.Any())
                .Select(x => CreateRecord(x));
        }

        private static StyleClass CreateRecord(IEnumerable<double> bucket)
        {
            var min = bucket.Min();
            var max = bucket.Max();
            var legend = $"{min} - {max}";
            return new GraduatedStyleClass
            {
                Min = min,
                Max = max,
                Legend = legend,
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
