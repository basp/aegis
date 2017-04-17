namespace Aegis.Vis
{
    using System;

    public class CategorizedStyleClass : StyleClass
    {
        private readonly string legend;

        public CategorizedStyleClass(string legend)
        {
            this.legend = legend;
        }

        public string Category { get; set; }

        public override string GetLegend() => this.legend;

        public override string GetSymbol()
        {
            throw new NotImplementedException();
        }
    }
}
