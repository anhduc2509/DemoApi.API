using DemoApi.Domain.Repository.Base.Command;
using DemoApi.Domain.Repository.Base.Query;
using DemoApi.Infracstructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Domain.Repository
{
    public interface IAccountQueryRepository : IQueyRepository<Account, string>
    {
        Task<Account> GetAccountByPhoneNumberAsync(string phoneNumber);
    }
}
