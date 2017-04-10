namespace Aegis.Sfa
{
    using System;

    public abstract class GeometryCollection : Geometry
    {
        private readonly Geometry[] geometries;

        protected GeometryCollection(Geometry[] geometries, int srid)
        {
            this.geometries = geometries;
            this.Srid = srid;
        }

        /// <summary>
        /// Returns a specified geometry in a <see cref="Geometry"/> collection.
        /// </summary>
        public virtual Geometry GeometryN(int n)
        {
            if (n < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            if (n > this.geometries.Length)
            {
                return null;
            }

            return this.geometries[n - 1];
        }

        public override string GeometryType() => nameof(GeometryCollection);

        public override bool IsEmpty() => this.geometries.Length == 0;

        /// <summary>
        /// Returns the number of geometries that comprise a <see cref="Geometry"/> instance.
        /// </summary>
        public virtual int NumGeometries() => this.geometries.Length;
    }
}
