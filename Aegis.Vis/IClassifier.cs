namespace Aegis.Vis
{
    using System.Collections.Generic;
    using Aegis.Data;

    public interface IClassifier<T>
    {
        IEnumerable<StyleClass> Classify(IEnumerable<T> data);
    }
}
