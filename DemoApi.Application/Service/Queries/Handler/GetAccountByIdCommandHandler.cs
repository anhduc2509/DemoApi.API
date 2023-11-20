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

namespace DemoApi.Application.Service.Queries.Handler
{
    public class GetAccountByIdCommandHandler : IRequestHandler<GetAccountByIdCommand, AccountDto>
    {
        private readonly IAccountQueryRepository _accountQueryRepository;
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public GetAccountByIdCommandHandler(IAccountQueryRepository accountQueryRepository, ICustomerQueryRepository customerQueryRepository)
        {
            _accountQueryRepository = accountQueryRepository;
            _customerQueryRepository = customerQueryRepository;
        }
        public async Task<AccountDto> Handle(GetAccountByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _accountQueryRepository.FindByIdAsync(request.Id);
                result.Customer = _customerQueryRepository.FindByIdAsync(request.Id).Result;
                var entityDto = MapperDto.Mapper.Map<AccountDto> (result);
                return entityDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
