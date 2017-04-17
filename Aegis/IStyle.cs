namespace Aegis
{
    using System.Collections.Generic;

    public interface IStyle
    {
        StyleType StyleType { get; }

        IStyleClass Discrete(string category);

        IStyleClass Graduated(double value);

        IEnumerable<IStyleClass> GetClasses();
    }
}
