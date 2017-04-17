namespace Aegis.Sfa
{
    using System;
    using System.IO;

    public abstract class Geometry : IGeometry
    {
        public int Srid { get; set; }

        public static Geometry FromBinary(byte[] bytes, int srid = 0)
        {
            throw new NotImplementedException();
        }

        public static Geometry FromText(string text, int srid = 0) =>
                    new WktParser(srid).Parse(text);

        public static T FromText<T>(string text, int srid = 0)
                    where T : Geometry => (T)FromText(text, srid);

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
        public virtual string AsText()
        {
            using (var stream = new MemoryStream())
            using (var writer = WktWriter.Create(stream))
            {
                writer.Write(this);
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

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