using Dapper;
using DemoApi.Domain.Entity.Base;
using DemoApi.Domain.Repository.Base.Query;
using DemoApi.Infracstructure.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DemoApi.Infracstructure.Repository.Base.Query
{
    public abstract class QueryRepository<TEntity, TKey> : DapperConnect, IQueyRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        protected virtual string TableName { get; set; } = typeof(TEntity).Name;
        protected QueryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<TEntity> FindByIdAsync(TKey id)
        {
            var dynamicParam = new DynamicParameters();
            dynamicParam.Add("id", id);
            var query = $"SELECT * FROM {TableName} WHERE Id = @id";
            using (var connect = GetConnection())
            {
                var result = await connect.QuerySingleOrDefaultAsync<TEntity>(query, dynamicParam);
                return result;
            }

        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            var query = $"SELECT * FROM {TableName}";
            using (var connect = GetConnection())
            {
                var result = await connect.QueryAsync<TEntity>(query);
                return result.ToList();
            }
        }

        public async Task<TEntity> GetAsync(TEntity entity)
        {
            var check = await FindByIdAsync(entity.GetKey());
            if (check == null)
            {
                throw new Exception("Khong ton tai nguoi dung");
            }
            return check;
        }
    }
}
