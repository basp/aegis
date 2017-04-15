namespace Aegis.Shp
{
    public struct Box
    {
        public readonly double Xmin;
        public readonly double Ymin;
        public readonly double Xmax;
        public readonly double Ymax;

        internal Box(double xMin, double yMin, double xMax, double yMax)
        {
            this.Xmin = xMin;
            this.Ymin = yMin;
            this.Xmax = xMax;
            this.Ymax = yMax;
        }
    }
}
