namespace Aegis.Shp
{
    using System;

    public struct Point : IGeometry
    {
        public readonly double X;
        public readonly double Y;

        internal Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public byte[] AsBinary() =>
            throw new NotImplementedException();

        public string AsText() =>
            $"POINT ({this.X} {this.Y})";

        internal string AsTextNoIdentNoParens() =>
            $"{this.X} {this.Y}";
    }
}
