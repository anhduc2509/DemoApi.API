using DemoApi.Application.Dto;
using DemoApi.Application.Service.Mapper;
using DemoApi.Domain.Repository;
using DemoApi.Infracstructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Application.Service.Commands.Handler
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, AccountDto>
    {
        private readonly IAccountCommandRepository _accountCommandRepository;
        private readonly IAccountQueryRepository _accountQueryRepository;

        public UpdateAccountCommandHandler(IAccountCommandRepository accountCommandRepository, IAccountQueryRepository accountQueryRepository)
        {
            _accountCommandRepository = accountCommandRepository;
            _accountQueryRepository = accountQueryRepository;
        }

        public async Task<AccountDto> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var accountEntity = MapperDto.Mapper.Map<Account>(request);
            var check = await _accountQueryRepository.FindByIdAsync(request.Id);
            if (check != null)
            {
                try
                {
                    var rs = await _accountCommandRepository.UpdateAsync(accountEntity);
                    var accountDto = MapperDto.Mapper.Map<AccountDto>(rs);
                    return accountDto;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new Exception("Khong ton tai tai khoan");
            }
        }
    }
}
