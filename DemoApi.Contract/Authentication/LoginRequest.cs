using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Contracts.Authentication
{
    public record LoginRequest( string PhoneNumber, string Password );
}
