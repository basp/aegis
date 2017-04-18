namespace Aegis.Sql
{
    using System;

    public class Feature : IFeature
    {
        public int LayerId { get; private set; }

        public int Index { get; private set; }

        public double GetFieldAsDouble(int index)
        {
            throw new NotImplementedException();
        }

        public int GetFieldAsInt(int index)
        {
            throw new NotImplementedException();
        }

        public long GetFieldAsInt64(int index)
        {
            throw new NotImplementedException();
        }

        public string GetFieldAsString(int index)
        {
            throw new NotImplementedException();
        }

        public IGeometry GetGeometry()
        {
            throw new NotImplementedException();
        }
    }
}
