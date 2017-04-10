namespace Aegis.Vis
{
    using System;

    public interface IColorRamp
    {
        Tuple<double, double, double> GetColor(double n);
    }
}
