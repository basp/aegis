namespace Aegis.Vis
{
    using System.Collections.Generic;

    public class SingleSymbolClassifier<T> : IClassifier<T>
    {
        private readonly IStyleClass symbol;

        public SingleSymbolClassifier(IStyleClass symbol)
        {
            this.symbol = symbol;
        }

        public static SingleSymbolClassifier<T> Create(IStyleClass symbol) =>
            new SingleSymbolClassifier<T>(symbol);

        public IEnumerable<IStyleClass> Classify(IEnumerable<T> data)
        {
            return new[] { this.symbol };
        }
    }
}
