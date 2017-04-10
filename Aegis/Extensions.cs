namespace Aegis
{
    using System;
    using System.IO;

    public static class Extensions
    {
        public static byte[] GetBytes(this int i, ByteOrder byteOrder)
        {
            switch (byteOrder)
            {
                case ByteOrder.XDR: return GetBytesXdr(i);
                case ByteOrder.NDR: return GetBytesNdr(i);
                default: throw new ArgumentException();
            }
        }

        public static byte[] GetBytes(this uint i, ByteOrder byteOrder)
        {
            switch (byteOrder)
            {
                case ByteOrder.XDR: return GetBytesXdr(i);
                case ByteOrder.NDR: return GetBytesNdr(i);
                default: throw new ArgumentException();
            }
        }

        public static byte[] GetBytes(this double d, ByteOrder byteOrder)
        {
            switch (byteOrder)
            {
                case ByteOrder.XDR: return GetBytesXdr(d);
                case ByteOrder.NDR: return GetBytesNdr(d);
                default: throw new ArgumentException();
            }
        }

        public static byte[] GetBytesNdr(this int i)
        {
            var bs = BitConverter.GetBytes(i);
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(bs);
            }

            return bs;
        }

        public static byte[] GetBytesNdr(this uint i)
        {
            var bs = BitConverter.GetBytes(i);
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(bs);
            }

            return bs;
        }

        public static byte[] GetBytesNdr(this double d)
        {
            var bs = BitConverter.GetBytes(d);
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(bs);
            }

            return bs;
        }

        public static byte[] GetBytesXdr(this int i)
        {
            var bs = BitConverter.GetBytes(i);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bs);
            }

            return bs;
        }

        public static byte[] GetBytesXdr(this uint i)
        {
            var bs = BitConverter.GetBytes(i);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bs);
            }

            return bs;
        }

        public static byte[] GetBytesXdr(this double d)
        {
            var bs = BitConverter.GetBytes(d);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bs);
            }

            return bs;
        }

        public static Type GetClrType(this FieldType self)
        {
            return FieldTypeConverter.GetClrType(self);
        }

        public static FieldType GetFieldType(this Type self)
        {
            return FieldTypeConverter.GetFieldType(self);
        }
        public static double ReadDouble(this BinaryReader reader, ByteOrder byteOrder)
        {
            switch (byteOrder)
            {
                case ByteOrder.XDR: return ReadDoubleXdr(reader);
                case ByteOrder.NDR: return ReadDoubleNdr(reader);
                default: throw new ArgumentException();
            }
        }

        public static double ReadDoubleNdr(this BinaryReader reader)
        {
            var bs = reader.ReadBytes(8);
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(bs);
            }

            return BitConverter.ToDouble(bs, 0);
        }

        public static double ReadDoubleXdr(this BinaryReader reader)
        {
            var bs = reader.ReadBytes(8);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bs);
            }

            return BitConverter.ToDouble(bs, 0);
        }

        public static int ReadInt32(this BinaryReader reader, ByteOrder byteOrder)
        {
            switch (byteOrder)
            {
                case ByteOrder.XDR: return ReadInt32Xdr(reader);
                case ByteOrder.NDR: return ReadInt32Ndr(reader);
                default: throw new ArgumentException();
            }
        }

        public static int ReadInt32Ndr(this BinaryReader reader)
        {
            var bs = reader.ReadBytes(sizeof(int));
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(bs);
            }

            return BitConverter.ToInt32(bs, 0);
        }

        public static int ReadInt32Xdr(this BinaryReader reader)
        {
            var bs = reader.ReadBytes(sizeof(int));
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bs);
            }

            return BitConverter.ToInt32(bs, 0);
        }

        public static uint ReadUInt32(this BinaryReader reader, ByteOrder byteOrder)
        {
            switch (byteOrder)
            {
                case ByteOrder.XDR: return ReadUInt32Xdr(reader);
                case ByteOrder.NDR: return ReadUInt32Ndr(reader);
                default: throw new ArgumentException();
            }
        }

        public static uint ReadUInt32Ndr(this BinaryReader reader)
        {
            var bs = reader.ReadBytes(sizeof(uint));
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(bs);
            }

            return BitConverter.ToUInt32(bs, 0);
        }

        public static uint ReadUInt32Xdr(this BinaryReader reader)
        {
            var bs = reader.ReadBytes(sizeof(uint));
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bs);
            }

            return BitConverter.ToUInt32(bs, 0);
        }

        public static void Write(this BinaryWriter writer, int i, ByteOrder byteOrder)
        {
            switch (byteOrder)
            {
                case ByteOrder.XDR:
                    writer.WriteXdr(i);
                    break;
                case ByteOrder.NDR:
                    writer.WriteNdr(i);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public static void Write(this BinaryWriter writer, uint i, ByteOrder byteOrder)
        {
            switch (byteOrder)
            {
                case ByteOrder.XDR:
                    writer.WriteXdr(i);
                    break;
                case ByteOrder.NDR:
                    writer.WriteNdr(i);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public static void Write(this BinaryWriter writer, double d, ByteOrder byteOrder)
        {
            switch (byteOrder)
            {
                case ByteOrder.XDR:
                    writer.WriteXdr(d);
                    break;
                case ByteOrder.NDR:
                    writer.WriteNdr(d);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public static void WriteNdr(this BinaryWriter writer, int i)
        {
            var buf = i.GetBytesNdr();
            writer.Write(buf);
        }

        public static void WriteNdr(this BinaryWriter writer, uint i)
        {
            var buf = i.GetBytesNdr();
            writer.Write(buf);
        }

        public static void WriteNdr(this BinaryWriter writer, double d)
        {
            var buf = d.GetBytesNdr();
            writer.Write(buf);
        }

        public static void WriteXdr(this BinaryWriter writer, int i)
        {
            var buf = i.GetBytesXdr();
            writer.Write(buf);
        }
        public static void WriteXdr(this BinaryWriter writer, uint i)
        {
            var buf = i.GetBytesXdr();
            writer.Write(buf);
        }
        public static void WriteXdr(this BinaryWriter writer, double d)
        {
            var buf = d.GetBytesXdr();
            writer.Write(buf);
        }
    }
}
