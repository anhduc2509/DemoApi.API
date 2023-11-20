using DemoApi.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Application.Service.Queries
{
    public class GetAllAccountQuery : IRequest<List<AccountDto>>
    {

    }
}
