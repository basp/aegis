namespace Aegis.Cfg
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class FieldValue
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
        [ForeignKey(nameof(Feature))]
        public int FeatureIndex
        {
            get;
            set;
        }

        [Key]
        [Column(Order = 3)]
        [ForeignKey(nameof(Feature))]
        public int FieldIndex
        {
            get;
            set;
        }

        public virtual Feature Feature
        {
            get;
            set;
        }
    }
}
