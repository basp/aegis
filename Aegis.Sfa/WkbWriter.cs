namespace Aegis.Sfa
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class WkbWriter : GeometryWriter, IDisposable
    {
        private const int DefaultBufferSize = 1024;
        private readonly BinaryWriter writer;
        private bool disposed = false;

        private WkbWriter(BinaryWriter writer)
            : base(writer.Flush)
        {
            this.writer = writer;
        }

        public static WkbWriter Create(Stream stream)
        {
            var writer = new BinaryWriter(
                stream,
                Encoding.UTF8,
                leaveOpen: true);

            return new WkbWriter(writer);
        }

        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.writer.Dispose();
            }

            this.disposed = true;
        }

        protected override void Write(Point point)
        {
            this.writer.Write(ByteOrder.NDR);
            this.writer.WriteNdr(WkbType.Point);
            this.Write(point.X, point.Y, ByteOrder.NDR);
        }

        protected override void Write(LineString lineString)
        {
            var numPoints = lineString.NumPoints();
            var points = Enumerable
                .Range(1, numPoints)
                .Select(n => lineString.PointN(n))
                .ToArray();

            this.writer.Write(ByteOrder.NDR);
            this.writer.WriteNdr(WkbType.LineString);
            this.writer.WriteNdr(numPoints);
            Array.ForEach(points, p => this.Write(p.X, p.Y));
        }

        protected override void Write(MultiPoint multiPoint)
        {
            var numPoints = multiPoint.NumGeometries();
            var points = Enumerable
                .Range(1, numPoints)
                .Select(n => multiPoint.GeometryN(n))
                .Cast<Point>()
                .ToArray();

            this.writer.Write(ByteOrder.NDR);
            this.writer.WriteNdr(WkbType.MultiPoint);
            this.writer.WriteNdr(numPoints);
            Array.ForEach(points, p => this.Write(p));
        }

        protected override void Write(MultiLineString multiLineString)
        {
            var numLineStrings = multiLineString.NumGeometries();
            var lineStrings = Enumerable
                .Range(1, numLineStrings)
                .Select(n => multiLineString.GeometryN(n))
                .Cast<LineString>()
                .ToArray();

            this.writer.Write(ByteOrder.NDR);
            this.writer.WriteNdr(WkbType.MultiLineString);
            this.writer.WriteNdr(numLineStrings);
            Array.ForEach(lineStrings, ls => this.Write(ls));
        }

        protected override void Write(MultiPolygon multiPolygon)
        {
            var numPolygons = multiPolygon.NumGeometries();
            var polygons = Enumerable
                .Range(1, numPolygons)
                .Select(n => multiPolygon.GeometryN(n))
                .Cast<Polygon>()
                .ToArray();

            this.writer.Write(ByteOrder.NDR);
            this.writer.WriteNdr(WkbType.MultiPolygon);
            this.writer.WriteNdr(numPolygons);
            Array.ForEach(polygons, p => this.Write(p));
        }

        protected override void Write(Polygon polygon)
        {
            var numInteriorRings = polygon.NumInteriorRing();
            var interiorRings = Enumerable
                .Range(1, numInteriorRings)
                .Select(n => polygon.InteriorRingN(n));

            var rings = new[] { polygon.ExteriorRing() }
                .Concat(interiorRings)
                .Cast<LinearRing>()
                .ToArray();

            var numRings = numInteriorRings + 1;
            this.writer.WriteNdr(numRings);
            Array.ForEach(rings, r => this.Write(r, ByteOrder.NDR));
        }

        protected override void Write(EmptyPoint point)
        {
            throw new NotImplementedException();
        }

        protected override void Write(EmptyLineString lineString)
        {
            throw new NotImplementedException();
        }

        protected override void Write(EmptyPolygon polygon)
        {
            throw new NotImplementedException();
        }

        private void Write(LinearRing linearRing, ByteOrder byteOrder)
        {
            var numPoints = linearRing.NumPoints();
            var points = Enumerable
                .Range(1, numPoints)
                .Select(n => linearRing.PointN(n))
                .ToArray();

            this.writer.Write(numPoints, byteOrder);
            Array.ForEach(points, p => this.Write(p.X, p.Y, byteOrder));
        }

        private void Write(
            double x,
            double y,
            ByteOrder byteOrder = ByteOrder.NDR)
        {
            this.writer.Write(x, byteOrder);
            this.writer.Write(y, byteOrder);
        }
    }
}
