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
                [typeof(long)] = FieldType.Long,
                [typeof(int)] = FieldType.Int,
            };

        public static Type GetClrType(FieldType dataType)
        {
            switch (dataType)
            {
                case FieldType.String: return typeof(string);
                case FieldType.Double: return typeof(double);
                case FieldType.Long: return typeof(long);
                case FieldType.Int: return typeof(int);
                default: throw new ArgumentException();
            }
        }

        public static FieldType GetFieldType(Type type)
        {
            return TypeMapping[type];
        }
    }
}
