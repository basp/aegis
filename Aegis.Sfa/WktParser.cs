namespace Aegis.Sfa
{
    using System.Globalization;
    using System.Linq;
    using Sprache;

    internal class WktParser
    {
        private const char COMMA = ',';
        private const char LPAREN = '(';
        private const char RPAREN = ')';

        private static readonly CultureInfo CultureInfo =
            new CultureInfo("en-US");

        private readonly int srid;

        public WktParser(int srid)
        {
            this.srid = srid;
        }

        internal Parser<Geometry> Geometry() =>
            this.Point().
            Or<Geometry>(this.EmptyPoint()).
            Or(this.LineString()).
            Or(this.EmptyLineString()).
            Or(this.Polygon()).
            Or(this.EmptyPolygon());

        private static Parser<char> Comma() =>
            Parse.Char(COMMA).Token();

        private static Parser<Coordinate> Coordinate() =>
            from lon in Double().Token()
            from lat in Double().Token()
            select new Coordinate(lon, lat);

        private static Parser<double> Double() =>
            from s in Parse.Decimal.Token().Text()
            select double.Parse(s);

        private static Parser<string> Empty() =>
            Parse.IgnoreCase("EMPTY").Token().Text();

        private static Parser<char> Lparen() =>
            Parse.Char(LPAREN).Token();

        private static Parser<char> Rparen() =>
            Parse.Char(RPAREN).Token();

        private Parser<EmptyLineString> EmptyLineString() =>
            from id in Parse.IgnoreCase(nameof(Sfa.LineString)).Token()
            from empty in Empty()
            select new EmptyLineString(this.srid);

        private Parser<EmptyPoint> EmptyPoint() =>
            from id in Parse.IgnoreCase(nameof(Sfa.Point)).Token()
            from empty in Empty()
            select new EmptyPoint(this.srid);

        private Parser<EmptyPolygon> EmptyPolygon() =>
            from id in Parse.IgnoreCase(nameof(Sfa.Polygon)).Token()
            from empty in Empty()
            select new EmptyPolygon(this.srid);

        private Parser<LineString> LineString() =>
            this.LineString(Parse.IgnoreCase(nameof(this.LineString)).Text());

        private Parser<LineString> LineString(Parser<string> ident) =>
            from id in ident.Token()
            from lparen in Lparen()
            from coords in Coordinate().DelimitedBy(Comma())
            from rparen in Rparen()
            let points = coords.Select(c => new Point(c.X, c.Y, this.srid))
            select new LineString(points.ToArray(), this.srid);

        private Parser<Point> Point() =>
            this.Point(Lparen(), Rparen());

        private Parser<Point> Point(
            Parser<string> ident) =>
            this.Point(ident, Lparen(), Rparen());

        private Parser<Point> Point(
            Parser<char> lparen,
            Parser<char> rparen) =>
            this.Point(Parse.IgnoreCase(nameof(Sfa.Point)).Text(), lparen, rparen);

        private Parser<Point> Point(
            Parser<string> ident,
            Parser<char> lparen,
            Parser<char> rparen) =>
            from id in ident.Token()
            from lp in lparen
            from coord in Coordinate()
            from rp in rparen
            select new Point(coord.X, coord.Y, this.srid);

        private Parser<Polygon> Polygon() =>
            this.Polygon(Parse.IgnoreCase(nameof(Sfa.Polygon)).Text());

        private Parser<Polygon> Polygon(
            Parser<string> ident) =>
            from id in ident
            from lparen in Lparen()
            from rings in this.LineString(Parse.Return(nameof(Sfa.LineString))).DelimitedBy(Comma())
            let exterior = rings.First()
            let interior = rings.Skip(1).ToArray()
            select new Polygon(exterior, interior, this.srid);
    }
}