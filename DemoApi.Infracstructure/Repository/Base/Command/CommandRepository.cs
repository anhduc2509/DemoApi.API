using DemoApi.Domain.Entity.Base;
using DemoApi.Domain.Repository.Base.Command;
using DemoApi.Infracstructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Infracstructure.Repository.Base.Command
{
    public abstract class CommandRepository<TEntity, TKey> : ICommandRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private readonly CustomerDbContext _customerDbContext;

        protected CommandRepository(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _customerDbContext.Set<TEntity>().AddAsync(entity);
            await _customerDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {

            _customerDbContext.Set<TEntity>().Remove(entity);
            await _customerDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _customerDbContext.Entry(entity).State = EntityState.Modified;
            await _customerDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
