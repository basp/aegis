namespace Aegis.Shp
{
    using System.IO;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct RecordHeader
    {
        public int RecordNumber;
        public int ContentLength;

        public static RecordHeader Read(BinaryReader reader)
        {
            RecordHeader h;
            h.RecordNumber = reader.ReadInt32Xdr();
            h.ContentLength = reader.ReadInt32Xdr();
            return h;
        }
    }
}
