namespace Aegis.Data
{
    using System.Data.Entity;
    using System.Linq;

    public class FeatureTypeRepository
    {
        private readonly DataContext context;

        public FeatureTypeRepository(DataContext context)
        {
            this.context = context;
        }

        public FeatureType Get(int id)
        {
            return this.context.FeatureTypes
                .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(FeatureType featureType)
        {
            this.context.FeatureTypes.Add(featureType);
            this.context.SaveChanges();
        }

        public void Update(FeatureType featureType)
        {
            this.context.FeatureTypes.Attach(featureType);
            this.context.Entry(featureType).State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
