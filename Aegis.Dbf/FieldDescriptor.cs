namespace Aegis.Dbf
{
    using System.IO;
    using System.Linq;
    using System.Text;

    public class FieldDescriptor
    {
        private string fieldName;
        private FieldType fieldType;
        private byte fieldLength;
        private byte decimalCount;

        private FieldDescriptor()
        {
        }

        public string FieldName => this.fieldName;

        public FieldType FieldType => this.fieldType;

        public byte FieldLength => this.fieldLength;

        public byte DecimalCount => this.decimalCount;

        public static FieldDescriptor Read(BinaryReader reader)
        {
            FieldDescriptor d = new FieldDescriptor();

            byte[] buf = reader.ReadBytes(11)
                .Where(x => x != 0x00) // Filter padding
                .ToArray();

            d.fieldName = Encoding.ASCII.GetString(buf);
            d.fieldType = (FieldType)reader.ReadByte();

            // Skip over reserved bytes
            reader.BaseStream.Seek(4, SeekOrigin.Current);

            d.fieldLength = reader.ReadByte();
            d.decimalCount = reader.ReadByte();

            // Skip over some junk and more reserved bytes
            //
            // * 2 bytes reserved
            // * 1 byte for the work area id
            // * 10 bytes reserved
            // * 1 byte for the production MDX flag
            //
            // Which totals 14 bytes of gunk we have to skip.
            reader.BaseStream.Seek(14, SeekOrigin.Current);

            return d;
        }
    }
}
