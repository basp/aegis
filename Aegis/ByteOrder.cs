namespace Aegis
{ 
    public enum ByteOrder : byte
    {
        /// <summary>
        /// Represents big-endian (most significant byte first) encoding.
        /// </summary>
        XDR = 0,

        /// <summary>
        /// Represents little-endian (least significant byte first) encoding.
        /// </summary>
        NDR = 1,
    }
}
