namespace Checklist.Core;

public interface IRepository<TEntity>
{
    void Add(TEntity entity);
    TEntity ById(int id);
}