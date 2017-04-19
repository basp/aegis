namespace Aegis.Shp
{
    using System;
    using System.IO;

    public class Dataset : IDataset, IDisposable
    {
        private readonly Stream shpStream;
        private readonly Stream dbfStream;
        private readonly string name;

        private bool disposed = false;

        private Dataset(
            string name,
            Stream shpStream,
            Stream dbfStream)
        {
            this.name = name;
            this.shpStream = shpStream;
            this.dbfStream = dbfStream;
        }

        public string Name => this.name;

        public static Dataset Create(string pathToShp)
        {
            var name = Path.GetFileNameWithoutExtension(pathToShp);
            var dir = Path.GetDirectoryName(pathToShp);
            var pathToDbf = Path.Combine(dir, string.Format("{0}.dbf", name));
            var shpStream = File.OpenRead(pathToShp);
            var dbfStream = File.OpenRead(pathToDbf);

            return new Dataset(name, shpStream, dbfStream);
        }

        public ILayer CreateLayer(string name)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public ILayer GetLayer(int index)
        {
            return Layer.Create(
                this.name,
                this.shpStream,
                this.dbfStream);
        }

        public ILayer GetLayerByName(string name)
        {
            throw new NotImplementedException();
        }

        public int GetLayerCount() => 1;

        protected void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.shpStream.Dispose();
                this.dbfStream.Dispose();
            }

            this.disposed = true;
        }
    }
}
