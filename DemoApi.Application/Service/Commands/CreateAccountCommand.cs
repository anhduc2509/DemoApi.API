using DemoApi.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Application.Service.Commands
{
    public class CreateAccountCommand : IRequest<AccountDto>
    {
        public string PhoneNumber { get; set; } = null!;

        public string Password { get; set; } = null!;

        public virtual CustomerDto? Customer { get; set; }
    }
}
