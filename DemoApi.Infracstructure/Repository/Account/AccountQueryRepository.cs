using Dapper;
using DemoApi.Domain.Repository;
using DemoApi.Infracstructure.Data;
using DemoApi.Infracstructure.Repository.Base.Command;
using DemoApi.Infracstructure.Repository.Base.Query;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Infracstructure.Repository
{
    public class AccountQueryRepository : QueryRepository<Account, string>, IAccountQueryRepository
    {
        public AccountQueryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Account> GetAccountByPhoneNumberAsync(string phoneNumber)
        {
            var dynamicParam = new DynamicParameters();
            dynamicParam.Add("phoneNumber", phoneNumber);
            var query = "SELECT * FROM account a WHERE a.PhoneNumber = @phoneNumber";
            using (var connect = GetConnection())
            {
                var result = await connect.QueryFirstOrDefaultAsync<Account>(query, dynamicParam);
                return result; 
            } 
        }

    }
}
