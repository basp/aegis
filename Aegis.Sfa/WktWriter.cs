namespace Aegis.Sfa
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class WktWriter : GeometryWriter, IDisposable
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
            : base(writer.Flush)
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

        protected void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                // TODO:
                // Find out why this fails because it
                // shouldn't touch the stream.
                //
                // this.writer.Dispose();
            }

            this.disposed = true;
        }

        protected override void Write(Point point)
        {
            this.WriteIdent<Point>();
            this.writer.Write(LPAREN);
            this.Write(point.X, point.Y);
            this.writer.Write(RPAREN);
        }

        protected override void Write(EmptyPoint point)
        {
            this.WriteIdent<Point>();
            this.writer.Write(SPACE);
            this.writer.Write(EMPTY);
        }

        protected override void Write(EmptyLineString lineString)
        {
            this.WriteIdent<LineString>();
            this.writer.Write(SPACE);
            this.writer.Write(EMPTY);
        }

        protected override void Write(EmptyPolygon polygon)
        {
            this.WriteIdent<Polygon>();
            this.writer.Write(SPACE);
            this.writer.Write(EMPTY);
        }

        protected override void Write(MultiPoint multiPoint)
        {
            var points = Enumerable
                .Range(1, multiPoint.NumGeometries())
                .Select(n => multiPoint.GeometryN(n))
                .Cast<Point>()
                .ToArray();

            this.WriteIdent<MultiPoint>();
            this.writer.Write(LPAREN);
            this.WriteSeparated(
                p => this.Write(p.X, p.Y),
                this.WriteSeparator,
                points);

            this.writer.Write(RPAREN);
        }

        protected override void Write(MultiPolygon multiPolygon)
        {
            var polygons = Enumerable
                .Range(1, multiPolygon.NumGeometries())
                .Select(n => multiPolygon.GeometryN(n))
                .Cast<Polygon>()
                .ToArray();

            this.WriteIdent<MultiPolygon>();
            this.writer.Write(LPAREN);
            this.WriteSeparated<Polygon>(
                p => this.Write(p, NoIdent),
                this.WriteSeparator,
                polygons);

            this.writer.Write(RPAREN);
        }

        protected override void Write(MultiLineString multiLineString)
        {
            var lineStrings = Enumerable
                .Range(1, multiLineString.NumGeometries())
                .Select(n => multiLineString.GeometryN(n))
                .Cast<LineString>()
                .ToArray();

            this.WriteIdent<MultiLineString>();
            this.writer.Write(LPAREN);
            this.WriteSeparated<LineString>(
                ls => this.Write(ls, NoIdent),
                this.WriteSeparator,
                lineStrings);

            this.writer.Write(RPAREN);
        }

        protected override void Write(LineString lineString) =>
            this.Write(lineString, this.WriteIdent<LineString>);

        protected override void Write(Polygon polygon) =>
            this.Write(polygon, this.WriteIdent<Polygon>);

        protected virtual void WriteSeparator()
        {
            this.writer.Write(COMMA);
            this.writer.Write(SPACE);
        }

        private void Write(Polygon polygon, Action writeIdent)
        {
            var interiorRings = Enumerable
                .Range(1, polygon.NumInteriorRing())
                .Select(n => polygon.InteriorRingN(n));

            var rings = new[] { polygon.ExteriorRing() }
                .Concat(interiorRings)
                .Cast<LinearRing>()
                .ToArray();

            writeIdent();

            this.writer.Write(LPAREN);
            this.WriteSeparated<LinearRing>(
                r => this.Write(r, NoIdent),
                this.WriteSeparator,
                rings);

            this.writer.Write(RPAREN);
        }

        private void Write(LineString lineString, Action writeIdent)
        {
            var points = Enumerable
                .Range(1, lineString.NumPoints())
                .Select(n => lineString.PointN(n))
                .ToArray();

            writeIdent();

            this.writer.Write(LPAREN);
            this.WriteSeparated(
                p => this.Write(p.X, p.Y),
                this.WriteSeparator,
                points);

            this.writer.Write(RPAREN);
        }

        private void WriteSeparated<T>(
            Action<T> writeElement,
            Action writeSeparator,
            params T[] elements)
        {
            var head = elements.First();
            var tail = elements.Skip(1);

            writeElement(head);
            foreach (var x in tail)
            {
                writeSeparator();
                writeElement(x);
            }
        }

        private void Write(double x, double y)
        {
            this.writer.Write(x);
            this.writer.Write(SPACE);
            this.writer.Write(y);
        }

        private void WriteIdent<T>()
        {
            this.writer.Write(typeof(T).Name.ToUpperInvariant());
            this.writer.Write(SPACE);
        }
    }
}
