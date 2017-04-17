namespace Aegis
{
    using System.Collections.Generic;

    public interface IStyle
    {
        StyleType StyleType { get; }

        IEnumerable<IStyleClass> GetClasses();
    }
}
