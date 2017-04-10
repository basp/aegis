namespace Aegis.Dbf
{
    using System.IO;

    public class FileHeader
    {
        private FileHeader(
            byte fileType,
            byte year,
            byte month,
            byte day,
            int numRecords,
            short numHeaderBytes,
            short numRecordBytes)
        {
            this.FileType = fileType;
            this.Year = year;
            this.Month = month;
            this.Day = day;
            this.NumRecords = numRecords;
            this.NumHeaderBytes = numHeaderBytes;
            this.NumRecordBytes = numRecordBytes;
        }

        public byte FileType { get; }

        public byte Year { get; }

        public byte Month { get; }

        public byte Day { get; }

        public int NumRecords { get; }

        public short NumHeaderBytes { get; }

        public short NumRecordBytes { get; }

        public static FileHeader Read(BinaryReader reader)
        {
            var h = new FileHeader(
                fileType: reader.ReadByte(),
                year: reader.ReadByte(),
                month: reader.ReadByte(),
                day: reader.ReadByte(),
                numRecords: reader.ReadInt32(),
                numHeaderBytes: reader.ReadInt16(),
                numRecordBytes: reader.ReadInt16());

            // Skip over all kinds of reserved bytes and junk:
            //
            // * 2 bytes reserved, filled with zeros
            // * 1 byte indidicating incomplete dBASE IV transactions
            // * 1 byte for the encryption flag
            // * 12 bytes reserved for multi-user processing
            // * 1 byte for some kind of MDX flag
            // * 1 byte for the language driver ID
            // * 2 bytes reserved, filled with zeros
            //
            // Which makes 20 bytes of gunk we have to skip.
            reader.BaseStream.Seek(20, SeekOrigin.Current);

            return h;
        }
    }
}
