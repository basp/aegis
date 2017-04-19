namespace Aegis.Cfg
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class Field : IFieldDefinition
    {
        [Key]
        [Column(Order = 1)]
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
