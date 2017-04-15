namespace Aegis.Shp
{
    using System.IO;
    using System.Linq;

    public static class Extensions
    {
        public static RecordHeader ReadRecordHeader(this BinaryReader reader)
        {
            var recordNumber = reader.ReadInt32Xdr();
            var contentLength = reader.ReadInt32Xdr();

            return new RecordHeader(recordNumber, contentLength);
        }

        public static Box ReadBox(this BinaryReader reader)
        {
            var xMin = reader.ReadDoubleNdr();
            var yMin = reader.ReadDoubleNdr();
            var xMax = reader.ReadDoubleNdr();
            var yMax = reader.ReadDoubleNdr();

            return new Box(xMin, yMin, xMax, yMax);
        }

        public static Point ReadPoint(this BinaryReader reader)
        {
            var x = reader.ReadDoubleNdr();
            var y = reader.ReadDoubleNdr();

            return new Point(x, y);
        }

        public static MultiPoint ReadMultiPoint(this BinaryReader reader)
        {
            var box = reader.ReadBox();
            var numPoints = reader.ReadInt32Ndr();

            var points = Enumerable.Range(0, numPoints)
                .Select(i => reader.ReadPoint())
                .ToArray();

            return new MultiPoint(box, numPoints, points);
        }

        public static PolyLine ReadPolyLine(this BinaryReader reader)
        {
            var box = reader.ReadBox();
            var numParts = reader.ReadInt32Ndr();
            var numPoints = reader.ReadInt32Ndr();

            var parts = Enumerable.Range(0, numParts)
                .Select(i => reader.ReadInt32Ndr())
                .ToArray();

            var points = Enumerable.Range(0, numPoints)
                .Select(i => reader.ReadPoint())
                .ToArray();

            return new PolyLine(box, numParts, numPoints, parts, points);
        }

        public static Polygon ReadPolygon(this BinaryReader reader)
        {
            var box = reader.ReadBox();
            var numParts = reader.ReadInt32Ndr();
            var numPoints = reader.ReadInt32Ndr();

            var parts = Enumerable.Range(0, numParts)
                .Select(i => reader.ReadInt32Ndr())
                .ToArray();

            var points = Enumerable.Range(0, numPoints)
                .Select(i => reader.ReadPoint())
                .ToArray();

            return new Polygon(box, numParts, numPoints, parts, points);
        }
    }
}
