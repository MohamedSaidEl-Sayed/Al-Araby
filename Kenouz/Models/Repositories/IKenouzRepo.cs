namespace Kenouz.Models.Repositories
{
    public interface IKenouzRepo<TEntity>
    {
        List<TEntity> GetAll();
        TEntity? Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
