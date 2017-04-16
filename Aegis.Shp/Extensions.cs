namespace Aegis.Shp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Aegis.Sfa;

    public static class Extensions
    {
        internal static RecordHeader ReadRecordHeader(this BinaryReader reader)
        {
            var recordNumber = reader.ReadInt32Xdr();
            var contentLength = reader.ReadInt32Xdr();

            return new RecordHeader(recordNumber, contentLength);
        }

        internal static Box ReadBox(this BinaryReader reader)
        {
            var xMin = reader.ReadDoubleNdr();
            var yMin = reader.ReadDoubleNdr();
            var xMax = reader.ReadDoubleNdr();
            var yMax = reader.ReadDoubleNdr();

            return new Box(xMin, yMin, xMax, yMax);
        }

        internal static Point ReadPoint(this BinaryReader reader)
        {
            var x = reader.ReadDoubleNdr();
            var y = reader.ReadDoubleNdr();

            return new Point(x, y);
        }

        internal static MultiPoint ReadMultiPoint(this BinaryReader reader)
        {
            var box = reader.ReadBox();
            var numPoints = reader.ReadInt32Ndr();

            var points = Enumerable.Range(0, numPoints)
                .Select(i => reader.ReadPoint())
                .ToArray();

            return new MultiPoint(box, numPoints, points);
        }

        internal static PolyLine ReadPolyLine(this BinaryReader reader)
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

        internal static Polygon ReadPolygon(this BinaryReader reader)
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

        internal static IEnumerable<ArraySegment<T>> GetParts<T>(this int[] offsets, T[] things)
        {
            var lastPart = offsets.Last();
            return offsets
                .Take(offsets.Length - 1)
                .Select((p, i) => Tuple.Create(p, offsets[i + 1] - p))
                .Concat(new[] { Tuple.Create(lastPart, things.Length - lastPart) })
                .Select(t => new ArraySegment<T>(things, t.Item1, t.Item2));
        }

        internal static double Shoelace(this Point[] points) =>
            new LinearRing(points).Shoelace();

        internal static double Shoelace(this ArraySegment<Point> ring) =>
            Shoelace(ring.ToArray());
    }
}
