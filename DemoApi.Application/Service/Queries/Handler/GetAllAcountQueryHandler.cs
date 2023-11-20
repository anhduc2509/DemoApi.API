using DemoApi.Application.Dto;
using DemoApi.Application.Service.Mapper;
using DemoApi.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Application.Service.Queries.Handler
{
    public class GetAllAcountQueryHandler : IRequestHandler<GetAllAccountQuery, List<AccountDto>>
    {
        private readonly IAccountQueryRepository _accountQueryRepository;
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public GetAllAcountQueryHandler(IAccountQueryRepository accountQueryRepository, ICustomerQueryRepository customerQueryRepository)
        {
            _accountQueryRepository = accountQueryRepository;
            _customerQueryRepository = customerQueryRepository;
        }

        public async Task<List<AccountDto>> Handle(GetAllAccountQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var listEntity = await _accountQueryRepository.GetAllAsync();
                var result = listEntity.Select( e =>
                {
                    var cus = _customerQueryRepository.FindByIdAsync(e.Id).Result;
                    e.Customer = cus;
                    var rs =  MapperDto.Mapper.Map<AccountDto>(e);
                    return rs;
                } ).ToList();
                return result;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
