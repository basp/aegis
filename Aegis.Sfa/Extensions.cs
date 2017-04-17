namespace Aegis.Sfa
{
    using System.IO;
    using System.Linq;

    public static class Extensions
    {
        /// <summary>
        /// The shoelace formula is a mathematical algorithm to determine
        /// the area of a simple polygon whose vertices are described by their
        /// Carthesian coordinates in the plane.
        /// </summary>
        /// <remarks>
        /// One of the cool things about this algorithm is that it can be used
        /// to determine whether a ring is CW (clockwise) or CCW (counter-clockwise).
        /// If the area returned is less than zero that means the vertices are in CCW
        /// order otherwise they are in CW order.
        /// </remarks>
        public static double Shoelace(this LinearRing ring)
        {
            var numPoints = ring.NumPoints();
            return Enumerable.Range(1, numPoints - 1)
                .Select(n => new { P1 = ring.PointN(n), P2 = ring.PointN(n + 1) })
                .Sum(e => (e.P2.X - e.P1.X) * (e.P2.Y + e.P1.Y));
        }

        internal static void WriteNdr(this BinaryWriter writer, WkbType wkbType)
        {
            writer.WriteNdr((int)wkbType);
        }

        internal static void WriteXdr(this BinaryWriter writer, WkbType wkbType)
        {
            writer.WriteXdr((int)wkbType);
        }
    }
}
