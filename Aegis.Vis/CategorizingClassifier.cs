namespace Aegis.Vis
{
    using System.Collections.Generic;
    using System.Linq;

    public class CategorizingClassifier : IClassifier<string>
    {
        public IEnumerable<IStyleClass> Classify(IEnumerable<string> data)
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
