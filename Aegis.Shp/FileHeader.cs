namespace Aegis.Shp
{
    using System.IO;

    public struct FileHeader
    {
        public int FileCode;
        public int Unused1;
        public int Unused2;
        public int Unused3;
        public int Unused4;
        public int Unused5;
        public int FileLength;
        public int Version;
        public int ShapeType;
        public Box Box;
        public double Zmin;
        public double Zmax;
        public double Mmin;
        public double Mmax;

        public static FileHeader Read(BinaryReader reader)
        {
            FileHeader h;

            h.FileCode = reader.ReadInt32Xdr();

            h.Unused1 = reader.ReadInt32Xdr();
            h.Unused2 = reader.ReadInt32Xdr();
            h.Unused3 = reader.ReadInt32Xdr();
            h.Unused4 = reader.ReadInt32Xdr();
            h.Unused5 = reader.ReadInt32Xdr();

            h.FileLength = reader.ReadInt32Xdr();
            h.Version = reader.ReadInt32Ndr();
            h.ShapeType = reader.ReadInt32Ndr();

            h.Box = reader.ReadBox();

            h.Zmin = reader.ReadDoubleNdr();
            h.Zmax = reader.ReadDoubleNdr();
            h.Mmin = reader.ReadDoubleNdr();
            h.Mmax = reader.ReadDoubleNdr();

            return h;
        }
    }
}
