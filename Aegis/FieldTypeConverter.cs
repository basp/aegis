namespace Aegis
{
    using System;
    using System.Collections.Generic;

    public static class FieldTypeConverter
    {
        private static readonly IDictionary<Type, FieldType> TypeMapping =
            new Dictionary<Type, FieldType>
            {
                [typeof(string)] = FieldType.String,
                [typeof(double)] = FieldType.Double,
                [typeof(long)] = FieldType.Int64,
                [typeof(int)] = FieldType.Int32,
            };

        public static Type GetClrType(FieldType dataType)
        {
            switch (dataType)
            {
                case FieldType.String: return typeof(string);
                case FieldType.Double: return typeof(double);
                case FieldType.Int64: return typeof(long);
                case FieldType.Int32: return typeof(int);
                default: throw new ArgumentException();
            }
        }

        public static FieldType GetFieldType(Type type)
        {
            return TypeMapping[type];
        }
    }
}
