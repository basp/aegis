namespace Aegis.Sfa
{
    using System;

    public abstract class GeometryWriter
    {
        private readonly Action flush;

        protected GeometryWriter(Action flush)
        {
            this.flush = flush;
        }

        public virtual void Write(Geometry geometry)
        {
            switch (geometry)
            {
                case EmptyPoint x:
                    this.Write(x);
                    this.flush();
                    return;
                case EmptyLineString x:
                    this.Write(x);
                    this.flush();
                    return;
                case EmptyPolygon x:
                    this.Write(x);
                    this.flush();
                    return;
                case Point x:
                    this.Write(x);
                    this.flush();
                    return;
                case LineString x:
                    this.Write(x);
                    this.flush();
                    return;
                case Polygon x:
                    this.Write(x);
                    this.flush();
                    return;
                case MultiPoint x:
                    this.Write(x);
                    this.flush();
                    return;
                case MultiLineString x:
                    this.Write(x);
                    this.flush();
                    return;
                case MultiPolygon x:
                    this.Write(x);
                    this.flush();
                    return;
            }

            throw new NotImplementedException();
        }

        protected abstract void Write(EmptyPoint point);

        protected abstract void Write(EmptyLineString lineString);

        protected abstract void Write(EmptyPolygon polygon);

        protected abstract void Write(Point point);

        protected abstract void Write(LineString lineString);

        protected abstract void Write(Polygon polygon);

        protected abstract void Write(MultiPoint multiPoint);

        protected abstract void Write(MultiLineString multiLineString);

        protected abstract void Write(MultiPolygon multiPolygon);
    }
}
