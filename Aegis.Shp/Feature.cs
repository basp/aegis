namespace Aegis.Shp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Feature : IFeature
    {
        private readonly ShapeType shapeType;
        private readonly int index;
        private readonly byte[] geometry;
        private readonly Tuple<string, string>[] fields;

        private Feature(
            ShapeType shapeType,
            int index,
            byte[] geometry)
            : this(shapeType, index, geometry, new List<Tuple<string, string>>())
        {
        }

        private Feature(
            ShapeType shapeType,
            int index,
            byte[] geometry,
            IEnumerable<Tuple<string, string>> fields)
        {
            this.shapeType = shapeType;
            this.index = index;
            this.geometry = geometry;
            this.fields = fields.ToArray();
        }

        public static IFeature Create(
            ShapeType shapeType,
            int index,
            byte[] buffer,
            IEnumerable<Tuple<string, string>> fields)
        {
            return new Feature(
                shapeType,
                index,
                buffer,
                fields);
        }

        public double GetFieldAsDouble(int index)
        {
            var @value = this.fields[index].Item2;
            return string.IsNullOrWhiteSpace(@value)
                ? default(double)
                : double.Parse(@value);
        }

        public int GetFieldAsInt(int index)
        {
            var @value = this.fields[index].Item2;
            return string.IsNullOrWhiteSpace(@value)
                ? default(int)
                : int.Parse(@value);
        }

        public long GetFieldAsInt64(int index)
        {
            var @value = this.fields[index].Item2;
            return string.IsNullOrWhiteSpace(@value)
                ? default(long)
                : long.Parse(@value);
        }

        public string GetFieldAsString(int index)
        {
            return this.fields[index].Item2;
        }

        public IGeometry GetGeometry()
        {
            switch (this.shapeType)
            {
                case ShapeType.Point:
                    break;
                case ShapeType.PolyLine:
                    break;
                case ShapeType.MultiPoint:
                    break;
                case ShapeType.Polygon:
                    break;
                default:
                    throw new ArgumentException();
            }

            throw new NotImplementedException();
        }
    }
}
