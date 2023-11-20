using DemoApi.Domain.Repository.Base.Command;
using DemoApi.Infracstructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Domain.Repository
{
    public interface ICustomerCommandRepository : ICommandRepository<Customer, string>
    {
    }
}
