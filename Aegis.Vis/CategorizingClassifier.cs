namespace Aegis.Vis
{
    using System.Collections.Generic;
    using System.Linq;
    using Aegis.Data;

    public class CategorizingClassifier : IClassifier<string>
    {
        public IEnumerable<StyleClass> Classify(IEnumerable<string> data)
        {
            return data.Distinct()
                .Select(x => new CategorizedStyleClass
                {
                    Category = x,
                    Legend = x,
                });
        }
    }
}
