using DemoApi.Infracstructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Application.Interface.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Account account);
    }
}
