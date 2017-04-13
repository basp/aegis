namespace Aegis.Data
{
    public interface IRepository<TEntity>
    {
        TEntity Find(params object[] keyValues);

        void Insert(TEntity entity);

        void Update(TEntity entity);
    }
}
