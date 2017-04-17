namespace Aegis.Sfa
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class WktWriter : IDisposable
    {
        private const int DefaultBufferSize = 1024;

        private const char COMMA = ',';
        private const string EMPTY = "EMPTY";
        private const char LPAREN = '(';
        private const char RPAREN = ')';
        private const char SPACE = ' ';

        private static readonly Action NoIdent = () => { };

        private readonly StreamWriter writer;

        private bool disposed = false;

        private WktWriter(StreamWriter writer)
        {
            this.writer = writer;
        }

        public static WktWriter Create(Stream stream)
        {
            var writer = new StreamWriter(
                stream,
                Encoding.ASCII,
                DefaultBufferSize,
                leaveOpen: true);

            return new WktWriter(writer);
        }

        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void Write(Geometry geometry)
        {
            throw new NotImplementedException();
        }

        public void Write(Point point)
        {
            this.WriteIdent<Point>();
            this.writer.Write(LPAREN);
            this.Write(point.X, point.Y);
            this.writer.Write(RPAREN);
        }

        public void Write(EmptyPoint point)
        {
            this.WriteIdent<Point>();
            this.writer.Write(SPACE);
            this.writer.Write(EMPTY);
        }

        public void Write(EmptyLineString lineString)
        {
            this.WriteIdent<LineString>();
            this.writer.Write(SPACE);
            this.writer.Write(EMPTY);
        }

        public void Write(EmptyPolygon polygon)
        {
            this.WriteIdent<Polygon>();
            this.writer.Write(SPACE);
            this.writer.Write(EMPTY);
        }

        public void Write(MultiPoint multiPoint)
        {
            var points = Enumerable
                .Range(1, multiPoint.NumGeometries())
                .Select(n => multiPoint.GeometryN(n))
                .Cast<Point>();

            this.WriteIdent<MultiPoint>();
            this.writer.Write(LPAREN);
            foreach (var p in points)
            {
                this.Write(p.X, p.Y);
                this.writer.Write(COMMA);
                this.writer.Write(SPACE);
            }

            this.writer.Write(RPAREN);
        }

        public void Write(MultiPolygon multiPolygon)
        {
            var polygons = Enumerable
                .Range(1, multiPolygon.NumGeometries())
                .Select(n => multiPolygon.GeometryN(n))
                .Cast<Polygon>();

            this.WriteIdent<MultiPolygon>();
            this.writer.Write(LPAREN);
            foreach (var p in polygons)
            {
                this.Write(p, NoIdent);
                this.writer.Write(COMMA);
                this.writer.Write(SPACE);
            }

            this.writer.Write(RPAREN);
        }

        public void Write(MultiLineString multiLineString)
        {
            var lineStrings = Enumerable
                .Range(1, multiLineString.NumGeometries())
                .Select(n => multiLineString.GeometryN(n))
                .Cast<LineString>();

            this.WriteIdent<MultiLineString>();
            this.writer.Write(LPAREN);
            foreach (var ls in lineStrings)
            {
                this.Write(ls, NoIdent);
                this.writer.Write(COMMA);
                this.writer.Write(SPACE);
            }

            this.writer.Write(RPAREN);
        }

        public void Write(LineString lineString) =>
            this.Write(lineString, this.WriteIdent<LineString>);

        public void Write(Polygon polygon) =>
            this.Write(polygon, this.WriteIdent<Polygon>);

        public void Write(Polygon polygon, Action writeIdent)
        {
            var interiorRings = Enumerable
                .Range(1, polygon.NumInteriorRing())
                .Select(n => polygon.InteriorRingN(n));

            var rings = new[] { polygon.ExteriorRing() }
                .Concat(interiorRings);

            writeIdent();

            this.writer.Write(LPAREN);
            foreach (var r in rings)
            {
                this.Write(r, NoIdent);
                this.writer.Write(COMMA);
                this.writer.Write(SPACE);
            }

            this.writer.Write(RPAREN);
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

        private void Write(LineString lineString, Action writeIdent)
        {
            var points = Enumerable
                .Range(1, lineString.NumPoints())
                .Select(n => lineString.PointN(n));

            writeIdent();

            this.writer.Write(LPAREN);
            foreach (var p in points)
            {
                this.Write(p.X, p.Y);
                this.writer.Write(COMMA);
                this.writer.Write(SPACE);
            }

            this.writer.Write(RPAREN);
        }

        private void Write(double x, double y)
        {
            this.writer.Write(x);
            this.writer.Write(SPACE);
            this.writer.Write(y);
        }

        private void WriteIdent<T>()
        {
            this.writer.Write(nameof(T).ToUpperInvariant());
            this.writer.Write(SPACE);
        }
    }
}
