using DemoApi.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Domain.Repository.Base.Query
{
    public interface IQueyRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(TEntity entity);
        Task<TEntity> FindByIdAsync(TKey id);
    }
}
