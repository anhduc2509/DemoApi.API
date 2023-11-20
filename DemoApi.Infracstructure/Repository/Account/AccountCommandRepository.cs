using DemoApi.Domain.Repository;
using DemoApi.Infracstructure.Data;
using DemoApi.Infracstructure.Repository.Base.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Infracstructure.Repository
{
    public class AccountCommandRepository : CommandRepository<Account, string>, IAccountCommandRepository
    {
        public AccountCommandRepository(CustomerDbContext customerDbContext) : base(customerDbContext)
        {
        }
    }
}
