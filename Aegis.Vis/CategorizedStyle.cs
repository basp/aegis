namespace Aegis.Vis
{
    using System;
    using System.Collections.Generic;

    public class CategorizedStyle : IStyle
    {
        public StyleType StyleType => throw new NotImplementedException();

        public IEnumerable<IStyleClass> GetClasses()
        {
            throw new NotImplementedException();
        }
    }
}
