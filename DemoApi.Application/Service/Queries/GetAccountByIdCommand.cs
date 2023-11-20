using DemoApi.Application.Dto;
using DemoApi.Infracstructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Application.Service.Queries
{
    public class GetAccountByIdCommand : IRequest<AccountDto>
    {
        public string Id { get; set; } = null!;

    }
}
