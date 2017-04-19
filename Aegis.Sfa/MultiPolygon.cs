namespace Aegis.Sfa
{
    using System;

    public class MultiPolygon : MultiSurface
    {
        private readonly Polygon[] polygons;

        public MultiPolygon(Polygon[] polygons, int srid)
            : base(polygons, srid)
        {
            this.polygons = polygons;
        }

        public MultiPolygon(params Polygon[] polygons)
            : this(polygons, 0)
        {
        }

        public override Geometry Centroid()
        {
            throw new NotImplementedException();
        }

        public override bool Contains(Geometry other)
        {
            throw new NotImplementedException();
        }

        public override int Dimension()
        {
            throw new NotImplementedException();
        }

        public override double Distance(Geometry other)
        {
            throw new NotImplementedException();
        }

        public override bool IsSimple()
        {
            throw new NotImplementedException();
        }
    }
}
