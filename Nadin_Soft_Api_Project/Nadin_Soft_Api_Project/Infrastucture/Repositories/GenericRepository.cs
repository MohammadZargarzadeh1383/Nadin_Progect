using Microsoft.EntityFrameworkCore;
using Nadin_Soft_Api_Project.Application.Interfaces.Repositories;
using Nadin_Soft_Api_Project.Domain.Entities.Common;
using Nadin_Soft_Api_Project.Infrastucture.ApplicationDb;
using Nadin_Soft_Api_Project.Domain.Enums.AppAction;

namespace Nadin_Soft_Api_Project.Infrastucture.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private ApplicationDbContext _context;
        private DbSet<TEntity> _entities;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }
        public async Task<int> Create(TEntity entity)
        {
            await _entities.AddAsync(entity);
            var save = await _context.SaveChangesAsync();
            return save;
        }
        public async Task<bool> Delete(TEntity entity)
        {
            entity.AppAction = AppAction.Deleted;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<int> Update(TEntity entity)
        {
            _entities.Update(entity);
            var save = await _context.SaveChangesAsync();
            return save;
        }
        public async Task<TEntity> GetById(int id)
        {
            var get = await _entities.FirstOrDefaultAsync(m => m.Id == id && m.AppAction == AppAction.Active);
            await _context.SaveChangesAsync();
            return get;
        }
        public IQueryable<TEntity> GetAll()
        {
            var getall = _entities.Where(m => m.AppAction == AppAction.Active);
            return getall;
        }

    }
}
