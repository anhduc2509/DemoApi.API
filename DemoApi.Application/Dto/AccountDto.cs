using DemoApi.Infracstructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Application.Dto
{
    public class AccountDto
    {
        public string Id { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Password { get; set; } = null!;

        public virtual CustomerDto Customer { get; set; } = null!;
    }
}
