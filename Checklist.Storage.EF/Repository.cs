using Checklist.Core;
using Microsoft.EntityFrameworkCore;

namespace Checklist.Storage.EF;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    private readonly DbSet<TEntity> _entities;
    private readonly DbContext _dbContext;

    public Repository(DbSet<TEntity> entities, DbContext dbContext)
    {
        _entities = entities;
        _dbContext = dbContext;
    }

    public void Add(TEntity entity)
    {
        _entities.Add(entity);
        _dbContext.SaveChanges();
    }

    public TEntity ById(int id) => _entities.First(entity => entity.Id == id);
}