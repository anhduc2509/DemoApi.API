using DemoApi.Domain.Repository;
using DemoApi.Infracstructure.Data;
using DemoApi.Infracstructure.Repository.Base.Query;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Infracstructure.Repository
{
    internal class CustomerQueyRepository : QueryRepository<Customer, string>, ICustomerQueryRepository
    {
        public CustomerQueyRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
