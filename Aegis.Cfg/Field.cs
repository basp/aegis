namespace Aegis.Cfg
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class Field : IFieldDefinition
    {
        private static class IndexNames
        {
            public const string LayerField = "IX_LayerId_FieldName";
        }

        [Key]
        [Column(Order = 1)]
        [Index(IndexNames.LayerField, Order = 1, IsUnique = true)]
        public int LayerId
        {
            get;
            set;
        }

        [Key]
        [Column(Order = 2)]
        public int Index
        {
            get;
            set;
        }

        [Index(IndexNames.LayerField, Order = 2, IsUnique = true)]
        [MaxLength(32)]
        public string Name
        {
            get;
            set;
        }

        public abstract int Precision
        {
            get;
        }

        public abstract FieldType Type
        {
            get;
        }

        public abstract int Width
        {
            get;
        }
    }
}
