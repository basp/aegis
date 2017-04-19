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
            // How the algorithm works is quite simple. For each line
            // segment in the ring it calculates the area below the segment
            // down to the x-axis. If we travel clockwise around the segments
            // of a linear ring in a plane, the area below the upper
            // segments (traveling to the right) is greater than the area
            // below the lower segments (traveling to the left). Thus if we
            // end up with a negative result we know that the points of the ring
            // are ordered in a CCW direction. If we end up with a positive
            // result we know that we traveled in CW direction. Note that to get
            // the actual area of the polygon (instead of a direction indicator)
            // we can just multiply the value of shoelace by 1/2.
            var numPoints = ring.NumPoints();
            return Enumerable.Range(1, numPoints - 1)
                .Select(n => new { P1 = ring.PointN(n), P2 = ring.PointN(n + 1) })
                .Sum(e => (e.P2.X - e.P1.X) * (e.P2.Y + e.P1.Y)); // shoelace
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
