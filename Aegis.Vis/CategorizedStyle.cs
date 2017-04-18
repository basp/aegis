namespace Aegis.Vis
{
    using System;
    using System.Collections.Generic;

    public class CategorizedStyle : IStyle
    {
        public StyleType StyleType => StyleType.Categorized;

        public IEnumerable<IStyleClass> GetClasses()
        {
            throw new NotImplementedException();
        }
    }
}
