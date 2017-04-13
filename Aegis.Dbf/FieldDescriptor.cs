namespace Aegis.Dbf
{
    using System.IO;
    using System.Linq;
    using System.Text;

    public class FieldDescriptor
    {
        private FieldDescriptor(
            string fieldName,
            FieldType fieldType,
            byte fieldLength,
            byte decimalCount)
        {
            this.FieldName = fieldName;
            this.FieldType = fieldType;
            this.FieldLength = fieldLength;
            this.DecimalCount = decimalCount;
        }

        public string FieldName { get; }

        public FieldType FieldType { get; }

        public byte FieldLength { get; }

        public byte DecimalCount { get; }

        public static FieldDescriptor Read(BinaryReader reader)
        {
            byte[] buf = reader.ReadBytes(11)
                .Where(x => x != 0x00) // Filter padding
                .ToArray();

            var fieldName = Encoding.ASCII.GetString(buf);
            var fieldType = (FieldType)reader.ReadByte();

            // Skip over reserved bytes
            reader.BaseStream.Seek(4, SeekOrigin.Current);

            var fieldLength = reader.ReadByte();
            var decimalCount = reader.ReadByte();

            // Skip over some junk and more reserved bytes:
            //
            // * 2 bytes reserved
            // * 1 byte for the work area id
            // * 10 bytes reserved
            // * 1 byte for the production MDX flag
            //
            // Which totals 14 bytes of gunk we have to skip.
            reader.BaseStream.Seek(14, SeekOrigin.Current);

            return new FieldDescriptor(
                fieldName,
                fieldType,
                fieldLength,
                decimalCount);
        }
    }
}
