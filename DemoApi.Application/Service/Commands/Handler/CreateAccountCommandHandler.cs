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
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, AccountDto>
    {
        private readonly IAccountCommandRepository _accountCommandRepository;
        private readonly IAccountQueryRepository _accountQueryRepository;
        private readonly ICustomerCommandRepository _customerCommandRepository;
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public CreateAccountCommandHandler(IAccountCommandRepository repository, IAccountQueryRepository queryRepository, ICustomerCommandRepository customerRepository, ICustomerQueryRepository customerQueryRepository)
        {
            _accountCommandRepository = repository;
            _accountQueryRepository = queryRepository;
            _customerCommandRepository = customerRepository;
            _customerQueryRepository = customerQueryRepository;
        }

        public async Task<AccountDto> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var accountEntity = MapperDto.Mapper.Map<Account>(request);
            if (accountEntity == null)
            {
                throw new Exception("Loi o mapperDto");
            }
            var check = await _accountQueryRepository.GetAccountByPhoneNumberAsync(accountEntity.PhoneNumber);
            if (check != null)
            {
                try
                {
                    var newAccount = await _accountCommandRepository.AddAsync(accountEntity);
                    var newCustomer = newAccount.Customer;
                    _ = await _customerCommandRepository.AddAsync(newCustomer);
                    var accountResponse = MapperDto.Mapper.Map<AccountDto>(newAccount);
                    return accountResponse;
                }
                catch (Exception ex)
                {
                    throw new Exception($"{ex.Message}", ex);
                }

            }
            else
            {
                throw new Exception("So dien thoai da ton tai");
            }
        }
    }
}
