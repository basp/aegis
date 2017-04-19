namespace Aegis.Sfa
{
    using System;
    using System.Linq;

    public class Polygon : Surface
    {
        private readonly LineString exteriorRing;
        private readonly LineString[] interiorRings;

        public Polygon(LineString exteriorRing, LineString[] interiorRings, int srid)
            : base(srid)
        {
            this.exteriorRing = exteriorRing;
            this.interiorRings = interiorRings;
            this.Srid = srid;
        }

        public Polygon(LineString exteriorRing, params LineString[] interiorRings)
            : this(exteriorRing, interiorRings, 0)
        {
        }

        public override double Area()
        {
            throw new NotImplementedException();
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

        public LineString ExteriorRing() => this.exteriorRing;

        public override string GeometryType()
        {
            throw new NotImplementedException();
        }

        public LineString InteriorRingN(int n) => this.interiorRings[n - 1];

        public override bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public override bool IsSimple()
        {
            throw new NotImplementedException();
        }

        public int NumInteriorRing() => this.interiorRings.Length;

        public override Point PointOnSurface()
        {
            throw new NotImplementedException();
        }
    }
}