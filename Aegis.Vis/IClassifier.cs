namespace Aegis.Vis
{
    using System.Collections.Generic;

    public interface IClassifier<T>
    {
        IEnumerable<IStyleClass> Classify(IEnumerable<T> data);
    }
}
