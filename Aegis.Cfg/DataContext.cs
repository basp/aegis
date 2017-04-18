namespace Aegis.Cfg
{
    using System.Data.Entity;
    using System.Data.Entity.SqlServer;

    public class DataContext : DbContext
    {
        private const string DefaultConnectionStringName = "Aegis";

        static DataContext()
        {
            var makeSureProviderIsCopied = SqlProviderServices.Instance;
        }

        public DataContext()
            : base(DefaultConnectionStringName)
        {
        }

        public virtual DbSet<Workspace> Workspaces
        {
            get;
            set;
        }

        public virtual DbSet<Dataset> Datasets
        {
            get;
            set;
        }

        public virtual DbSet<Layer> Layers
        {
            get;
            set;
        }

        public virtual DbSet<Feature> Features
        {
            get;
            set;
        }

        public virtual DbSet<Field> Fields
        {
            get;
            set;
        }

        public virtual DbSet<FieldValue> FieldValues
        {
            get;
            set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feature>()
                .HasKey(x => new { x.LayerId, x.Index });

            modelBuilder.Entity<FieldValue>()
                .HasRequired(x => x.Feature)
                .WithMany()
                .Map(x => x.MapKey("LayerId", "Index"));

            modelBuilder.Entity<Field>()
                .HasKey(x => new { x.LayerId, x.Index });

            modelBuilder.Entity<FieldValue>()
                .HasKey(x => new { x.LayerId, x.FeatureIndex, x.FieldIndex });
        }
    }
}
