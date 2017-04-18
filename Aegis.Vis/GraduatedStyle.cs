namespace Aegis.Vis
{
    using System;
    using System.Collections.Generic;

    public abstract class GraduatedStyle : IStyle
    {
        public StyleType StyleType => StyleType.Graduated;

        public IEnumerable<IStyleClass> GetClasses()
        {
            throw new NotImplementedException();
        }
    }
}
