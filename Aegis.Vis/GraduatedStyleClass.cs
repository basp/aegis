namespace Aegis.Vis
{
    using System;

    public class GraduatedStyleClass : StyleClass
    {
        private readonly string legend;

        public GraduatedStyleClass(string legend)
        {
            this.legend = legend;
        }

        public double? Min
        {
            get;
            set;
        }

        public double? Max
        {
            get;
            set;
        }

        public override string GetLegend() => this.legend;

        public override string GetSymbol()
        {
            throw new NotImplementedException();
        }
    }
}
