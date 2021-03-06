﻿namespace Aegis.Shp
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Aegis.Dbf;

    public class Layer : ILayer, IDisposable
    {
        private readonly DbfReader dbfReader;
        private readonly BinaryReader shpReader;
        private bool disposed = false;

        private int fp = 0;

        private Layer(
            string name,
            BinaryReader shpReader,
            DbfReader dbfReader)
        {
            this.Name = name;
            this.shpReader = shpReader;
            this.dbfReader = dbfReader;
        }

        public virtual string Name { get; }

        public static ILayer Create(
            string name,
            Stream shpStream,
            Stream dbfStream)
        {
            var shpReader = new BinaryReader(shpStream, Encoding.UTF8, leaveOpen: true);
            var dbfReader = DbfReader.Create(dbfStream);

            var layer = new Layer(
                name,
                shpReader,
                dbfReader);

            layer.Reset();
            return layer;
        }

        public virtual void CreateField(IFieldDefinition field)
        {
            throw new NotImplementedException();
        }

        public virtual void DeleteField(int index)
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public virtual int GetFeatureCount(bool force = false) => -1;

        public virtual IFeatureDefinition GetLayerDefinition()
        {
            return new FeatureDefinition(
                this.dbfReader.FieldDescriptors.ToArray());
        }

        public virtual IFeature GetNextFeature()
        {
            if (this.EOF())
            {
                return null;
            }

            var fields = this.dbfReader.GetRecord(this.fp);
            var header = this.shpReader.ReadRecordHeader();

            // Content length is in words so multiply by `sizeof(short))` to get
            // the number of bytes. The value of `contentLength` also contains
            // the bytes to designate the type of geometry.
            var contentLength = header.ContentLength * sizeof(short);
            var bytes = this.shpReader.ReadBytes(contentLength);
            return Feature.Create(
                this.fp++, // Updating this inline is a bit sneaky
                bytes,
                fields);
        }

        public virtual void Reset()
        {
            // Shapefile file header is fixed 100 bytes (just skip them)
            this.shpReader.BaseStream.Seek(100, SeekOrigin.Begin);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.shpReader.Dispose();
                this.dbfReader.Dispose();
            }

            this.disposed = true;
        }

        private bool EOF()
        {
            var stream = this.shpReader.BaseStream;
            return stream.Position == stream.Length;
        }
    }
}