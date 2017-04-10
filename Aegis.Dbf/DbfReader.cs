namespace Aegis.Dbf
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DbfReader : IDisposable
    {
        private const byte EndOfFile = 0x1A;

        private readonly BinaryReader reader;
        private readonly FileHeader header;
        private readonly FieldDescriptor[] fieldDescriptors;

        private bool disposed = false;

        private DbfReader(
            FileHeader header,
            FieldDescriptor[] fields,
            Stream stream)
        {
            this.header = header;
            this.fieldDescriptors = fields;
            this.reader = new BinaryReader(
                stream,
                Encoding.UTF8,
                leaveOpen: true);
        }

        public IEnumerable<FieldDescriptor> FieldDescriptors => this.fieldDescriptors;

        public int RecordCount => this.header.NumRecords;

        public int RecordSize => this.header.NumRecordBytes;

        public int HeaderSize => this.header.NumHeaderBytes;

        /// <summary>
        /// Creates a new reader from a stream object. The routine assumes
        /// that the stream is positioned right at the spot where the DBF data
        /// begins. Usually this is at position 0.
        /// </summary>
        /// <param name="stream">The seekable stream to read from.</param>
        /// <returns>A reader that is set to read data records.</returns>
        public static DbfReader Create(Stream stream)
        {
            using (var reader = new BinaryReader(stream, Encoding.UTF8, leaveOpen: true))
            {
                var header = FileHeader.Read(reader);
                const byte FieldTerminator = 0x0D;

                var fields = new List<FieldDescriptor>();
                while (reader.PeekChar() != FieldTerminator)
                {
                    fields.Add(FieldDescriptor.Read(reader));
                }

                return new DbfReader(header, fields.ToArray(), stream);
            }
        }

        /// <summary>
        /// Offers random access into the record collection.
        /// </summary>
        /// <param name="index">The index of the record to fetch.</param>
        /// <returns>A name-value pair for each field int he record.</returns>
        public IEnumerable<Tuple<string, string>> GetRecord(int index)
        {
            var bs = this.ReadRecordBytes(index);
            var mark = bs[0];
            var contents = bs.Skip(1).ToArray();
            var offset = 0;
            var record = new List<Tuple<string, string>>();

            foreach (var f in this.fieldDescriptors)
            {
                string @value;
                switch (f.FieldType)
                {
                    case FieldType.Character:
                        @value = Encoding.ASCII
                            .GetString(contents, offset, f.FieldLength)
                            .Trim();

                        record.Add(Tuple.Create(f.FieldName, @value));

                        break;
                    case FieldType.Numeric:
                        @value = Encoding.ASCII
                            .GetString(contents, offset, f.FieldLength)
                            .Trim();

                        record.Add(Tuple.Create(f.FieldName, @value));
                        break;
                }

                offset += f.FieldLength;
            }

            return record;
        }

        public DateTime GetDate()
        {
            const int baseYear = 1900;
            var year = baseYear + this.header.Year;
            return new DateTime(
                year,
                this.header.Month,
                this.header.Day);
        }

        public virtual void Reset()
        {
            this.reader.BaseStream.Seek(this.HeaderSize, SeekOrigin.Begin);
        }

        public virtual void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.reader.Dispose();
            }

            this.disposed = true;
        }

        private byte[] ReadRecordBytes(int index)
        {
            var offset = this.HeaderSize + (index * this.RecordSize);
            this.reader.BaseStream.Seek(offset, SeekOrigin.Begin);
            return this.reader.ReadBytes(this.RecordSize);
        }
    }
}
