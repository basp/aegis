namespace Aegis.Vis
{
    using System.Collections.Generic;
    using Aegis.Data;

    public class SingleSymbolClassifier<T> : IClassifier<T>
    {
        private readonly StyleClass symbol;

        public SingleSymbolClassifier(StyleClass symbol)
        {
            this.symbol = symbol;
        }

        public static SingleSymbolClassifier<T> Create(StyleClass symbol) =>
            new SingleSymbolClassifier<T>(symbol);

        public IEnumerable<StyleClass> Classify(IEnumerable<T> data)
        {
            return new[] { this.symbol };
        }
    }
}
