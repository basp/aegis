namespace Aegis.Shp
{
    using System;

    public class NotImplementedGeometry : IGeometry
    {
        private readonly ShapeType type;

        public NotImplementedGeometry(ShapeType type)
        {
            this.type = type;
        }

        public byte[] AsBinary()
        {
            throw new NotImplementedException();
        }

        public string AsText() => "NOT IMPLEMENTED ({this.type})";
    }
}
