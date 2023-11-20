using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Application.Dto
{
    public class CustomerDto
    {
        public string Id { get; set; } = null!;

        public string FristName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Email { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public string? Address { get; set; }
        public virtual AccountDto IdNavigation { get; set; } = null!;

    }
}
