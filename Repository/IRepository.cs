using Domain.Models;
using System.Linq.Expressions;

namespace Repository
{
    public interface IRepository
    {
        Task<List<TEntity>> GetAllAsync<TEntity>()
            where TEntity : BaseEntity;

        Task<TEntity> GetByIdAsync<TEntity>(int id)
            where TEntity : BaseEntity;

        public Task<List<TEntity>> GetByPredicateAsync<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : BaseEntity;


        Task<TEntity> InsertAsync<TEntity>(TEntity entity)
            where TEntity : BaseEntity;

        Task<TEntity> UpdateAsync<TEntity>(TEntity entity)
            where TEntity : BaseEntity;

        Task<TEntity> DeleteAsync<TEntity>(int id)
            where TEntity : BaseEntity;
    }
}
