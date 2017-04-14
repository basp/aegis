namespace Aegis.Data
{
    using System.Data.Entity;
    using System.Linq;

    public class DatasetRepository
    {
        private readonly DataContext context;

        public DatasetRepository(DataContext context)
        {
            this.context = context;
        }

        public Dataset Get(int id)
        {
            return this.context.Datasets
                .Include(x => x.Features.Select(y => y.FieldValues))
                .Include(x => x.FeatureType.Fields)
                .Include(x => x.PropertyValues)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Dataset entity)
        {
            this.context.Datasets.Add(entity);
            this.context.SaveChanges();
        }

        public void Update(Dataset entity)
        {
            this.context.Datasets.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
