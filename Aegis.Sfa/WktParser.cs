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
            Point().
            Or<Geometry>(EmptyPoint()).
            Or(LineString()).
            Or(EmptyLineString()).
            Or(Polygon()).
            Or(EmptyPolygon());

        private static Parser<string> Empty() =>
            Parse.String("EMPTY").Token().Text();

        private Parser<EmptyPoint> EmptyPoint() =>
            from id in Parse.String(nameof(Point).ToUpperInvariant()).Token()
            from empty in Empty()
            select new EmptyPoint(this.srid);

        private Parser<EmptyLineString> EmptyLineString() =>
            from id in Parse.String(nameof(LineString).ToUpperInvariant()).Token()
            from empty in Empty()
            select new EmptyLineString(this.srid);

        private Parser<EmptyPolygon> EmptyPolygon() =>
            from id in Parse.String(nameof(Polygon).ToUpperInvariant()).Token()
            from empty in Empty()
            select new EmptyPolygon(this.srid);

        private static Parser<char> Comma() =>
            Parse.Char(COMMA).Token();

        private static Parser<Coordinate> Coordinate() =>
            from lon in Double().Token()
            from lat in Double().Token()
            select new Coordinate(lon, lat);

        private static Parser<double> Double() =>
            from s in Parse.Decimal.Token().Text()
            select double.Parse(s);

        private static Parser<char> Lparen() =>
            Parse.Char(LPAREN).Token();

        private static Parser<char> Rparen() =>
            Parse.Char(RPAREN).Token();

        private Parser<LineString> LineString() =>
            LineString(Parse.String(nameof(LineString).ToUpperInvariant()).Text());

        private Parser<LineString> LineString(Parser<string> ident) =>
            from id in ident.Token()
            from lparen in Lparen()
            from coords in Coordinate().DelimitedBy(Comma())
            from rparen in Rparen()
            let points = coords.Select(c => new Point(c.X, c.Y, this.srid))
            select new LineString(points.ToArray(), this.srid);

        private Parser<Point> Point() =>
            Point(Lparen(), Rparen());

        private Parser<Point> Point(
            Parser<string> ident) =>
            Point(ident, Lparen(), Rparen());

        private Parser<Point> Point(
            Parser<char> lparen,
            Parser<char> rparen) =>
            Point(Parse.String(nameof(Point).ToUpperInvariant()).Text(), lparen, rparen);

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
            Polygon(Parse.String(nameof(Polygon).ToUpperInvariant()).Text());

        private Parser<Polygon> Polygon(
            Parser<string> ident) =>
            from id in ident
            from lparen in Lparen()
            from rings in LineString(Parse.Return(nameof(LineString).ToUpperInvariant())).DelimitedBy(Comma())
            let exterior = rings.First()
            let interior = rings.Skip(1).ToArray()
            select new Polygon(exterior, interior, this.srid);
    }
}
