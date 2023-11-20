using DemoApi.Domain.Repository;
using DemoApi.Domain.Repository.Base.Command;
using DemoApi.Infracstructure.Data;
using DemoApi.Infracstructure.Repository.Base.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Infracstructure.Repository
{
    public class CustomerCommandRepository : CommandRepository<Customer, string>, ICustomerCommandRepository
    {
        public CustomerCommandRepository(CustomerDbContext customerDbContext) : base(customerDbContext)
        {
        }
    }
}
