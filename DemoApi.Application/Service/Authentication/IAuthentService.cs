using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Application.Service.Authentication
{
    public interface IAuthentService
    {
        Task<AuthentResult> Login(string username, string password);
        //AuthentResult Register()
    }
}
