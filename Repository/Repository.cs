using AutoMapper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public class Repository : IRepository
    {
        private readonly Lab2Context _context;
        private readonly IMapper _mapper;
        public Repository(Lab2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TEntity> DeleteAsync<TEntity>(int id)
            where TEntity : BaseEntity
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            if (entity == null)
            {
                return entity;
            }

            _context.Set<TEntity>().Remove(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<TEntity>> GetByPredicateAsync<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : BaseEntity
        {
            var list = await _context.Set<TEntity>().Where(predicate).ToListAsync();

            return list;
        }

        public async Task<List<TEntity>> GetAllAsync<TEntity>()
            where TEntity : BaseEntity
        {
            var result = await _context.Set<TEntity>().ToListAsync();
            return result;
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(int id)
            where TEntity : BaseEntity
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<TEntity> InsertAsync<TEntity>(TEntity entity)
            where TEntity : BaseEntity
        {
            var addedEntity = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return addedEntity.Entity;
        }

        public async Task<TEntity> UpdateAsync<TEntity>(TEntity newEntity)
            where TEntity : BaseEntity
        {
            var entity = await _context.Set<TEntity>().Where(i => i.Id == newEntity.Id).FirstAsync();
            _mapper.Map(newEntity, entity);

            await _context.SaveChangesAsync();

            return entity;
        }
    }
}