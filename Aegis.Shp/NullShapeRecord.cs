namespace Aegis.Shp
{
    using System.IO;

    public struct NullShapeRecord
    {
        public int ShapeType;

        public static NullShapeRecord Read(BinaryReader reader)
        {
            return new NullShapeRecord
            {
                ShapeType = (int)Shp.ShapeType.NullShape,
            };
        }
    }
}
