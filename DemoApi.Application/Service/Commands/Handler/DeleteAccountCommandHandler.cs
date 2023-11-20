using DemoApi.Application.Dto;
using DemoApi.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Application.Service.Commands.Handler
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, string>
    {
        private readonly IAccountCommandRepository _accountCommandRepository;
        private readonly IAccountQueryRepository _accountQueryRepository;

        public DeleteAccountCommandHandler(IAccountCommandRepository accountCommandRepository, IAccountQueryRepository accountQueryRepository)
        {
            _accountCommandRepository = accountCommandRepository;
            _accountQueryRepository = accountQueryRepository;
        }

        public async Task<string> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var check = await _accountQueryRepository.FindByIdAsync(request.id);
            if (check != null)
            {
                try
                {
                    await _accountCommandRepository.DeleteAsync(check);
                    return "Nguoi dung da duoc xoa";
                } catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            } else
            {
                throw new Exception("Khong ton tai nguoi dung");
            } 
        }
    }
}
