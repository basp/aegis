namespace Aegis.Shp
{
    using System.IO;

    public struct RecordHeader
    {
        public readonly int RecordNumber;
        public readonly int ContentLength;

        public RecordHeader(int recordNumber, int contentLength)
        {
            this.RecordNumber = recordNumber;
            this.ContentLength = contentLength;
        }
    }
}
