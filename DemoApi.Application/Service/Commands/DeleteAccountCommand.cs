using DemoApi.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Application.Service.Commands
{
    public class DeleteAccountCommand : IRequest<string>
    {
        public string id { get; private set; }

        public DeleteAccountCommand(string id)
        {
            this.id = id;
        }
    }
}
