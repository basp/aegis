namespace Aegis.Shp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Feature : IFeature
    {
        private readonly byte[] bytes;
        private readonly Tuple<string, string>[] fields;
        private readonly int index;

        private Feature(
            int index,
            byte[] bytes,
            IEnumerable<Tuple<string, string>> fields)
        {
            this.index = index;
            this.bytes = bytes;
            this.fields = fields.ToArray();
        }

        public static IFeature Create(
            int index,
            byte[] bytes,
            IEnumerable<Tuple<string, string>> fields) =>
            new Feature(index, bytes, fields);

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

        public string GetFieldAsString(int index) =>
            this.fields[index].Item2;

        public IGeometry GetGeometry()
        {
            using (var stream = new MemoryStream(this.bytes))
            using (var reader = new BinaryReader(stream))
            {
                var type = (ShapeType)reader.ReadInt32Ndr();
                switch (type)
                {
                    case ShapeType.NullShape:
                        return null;
                    case ShapeType.Point:
                        return reader.ReadPoint();
                    case ShapeType.MultiPoint:
                        return reader.ReadMultiPoint();
                    case ShapeType.PolyLine:
                        return reader.ReadPolyLine();
                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}
