namespace Aegis.Sfa
{
    public abstract class Geometry
    {
        public int Srid { get; set; }

        /// <summary>
        /// Returns the Open Geospatial Consortium (OGC) Well-Known Binary (WKB) 
        /// representation of a <see cref="Geometry"/> instance.
        /// </summary>
        public abstract byte[] AsBinary();

        /// <summary>
        /// Returns the Open Geospatial Consortium (OGC) Well-Known Text (WKT) 
        /// representation of a <see cref="Geometry"/> instance.
        /// </summary>
        /// <remarks>
        /// This text will not contain any Z (elevation) or M (measure) values 
        /// carried by the instance.
        /// </remarks>
        public abstract string AsText();

        /// <summary>
        /// Returns the geometric center of a <see cref="Geometry"/> instance that 
        /// consists of one or more polygons.
        /// </summary>
        public abstract Geometry Centroid();

        /// <summary>
        /// Returns <c>true</c> if a <see cref="Geometry"/> instance completely 
        /// contains another <see cref="Geometry"/> instance. Returns <c>false</c> if 
        /// it does not.
        /// </summary>
        public abstract bool Contains(Geometry other);

        /// <summary>
        /// Returns the maximum dimension of a <see cref="Geometry"/> instance.
        /// </summary>
        /// <returns></returns>
        public abstract int Dimension();

        /// <summary>
        /// Returns the shortest distance between a point in a <see cref="Geometry"/> 
        /// instance and a point in another <see cref="Geometry"/> instance.
        /// </summary>
        public abstract double Distance(Geometry other);

        public abstract string GeometryType();

        /// <summary>
        /// Returns <c>true</c> if a <see cref="Geometry"/> instance is empty. 
        /// Returns <c>false</c> if a <see cref="Geometry"/> instance is not empty.
        /// </summary>
        public abstract bool IsEmpty();

        public abstract bool IsSimple();
    }
}
