using DemoApi.Application.Dto;
using DemoApi.Infracstructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Application.Service.Commands
{
    public class UpdateAccountCommand : IRequest<AccountDto>
    {
        public string Id { get; set; }
        public string PhoneNumber { get; set; } 
        public string Password { get; set; } 

    }
}
