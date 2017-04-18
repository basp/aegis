namespace Aegis.Vis
{
    using System;
    using System.Collections.Generic;

    public abstract class DynamicStyle : IStyle
    {
        public StyleType StyleType => StyleType.Dynamic;

        public IEnumerable<IStyleClass> GetClasses()
        {
            throw new NotImplementedException();
        }
    }
}
