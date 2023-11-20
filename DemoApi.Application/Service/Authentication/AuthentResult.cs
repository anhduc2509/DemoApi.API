using DemoApi.Infracstructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Application.Service.Authentication
{
    public record AuthentResult
    (
        string id,
        string phoneNumber,
        Customer customer,
        DateTime createdDate,
        DateTime modifiedDate,
        string Token
     );

}
