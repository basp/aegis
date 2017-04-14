namespace Aegis.Data
{
    using System.Data.Entity;
    using Serilog;

    public class DataContext : DbContext
    {
        static DataContext()
        {
            var provider = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DataContext()
            : base("Aegis")
        {
            this.Database.Log = Log.Debug;
        }

        public virtual DbSet<Dataset> Datasets
        {
            get;
            set;
        }

        public virtual DbSet<Feature> Features
        {
            get;
            set;
        }

        public virtual DbSet<FeatureType> FeatureTypes
        {
            get;
            set;
        }

        public virtual DbSet<Layer> Layers
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

        public virtual DbSet<Style> Styles
        {
            get;
            set;
        }

        public virtual DbSet<StyleClass> StyleClasses
        {
            get;
            set;
        }

        public virtual DbSet<Workspace> Workspaces
        {
            get;
            set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Dataset>()
            //    .Ignore(x => x.DataTable);

            modelBuilder.Entity<Feature>()
                .HasKey(x => new { x.DatasetId, x.Index });

            modelBuilder.Entity<Field>()
                .HasKey(x => new { x.FeatureTypeId, x.Index });

            modelBuilder.Entity<FieldValue>()
                .HasKey(x => new { x.DatasetId, x.FeatureIndex, x.FieldIndex });

            modelBuilder.Entity<StyleClass>()
                .HasKey(x => new { x.StyleId, x.Index });
        }
    }
}
