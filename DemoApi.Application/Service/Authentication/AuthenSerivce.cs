using DemoApi.Application.Interface.Authentication;
using DemoApi.Domain.Repository;
using DemoApi.Infracstructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Application.Service.Authentication
{
    public class AuthenSerivce : IAuthentService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IAccountQueryRepository _accountQueryRepository;
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public AuthenSerivce(IJwtTokenGenerator jwtTokenGenerator, IAccountQueryRepository accountQueryRepository, ICustomerQueryRepository customerQueryRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _accountQueryRepository = accountQueryRepository;
            _customerQueryRepository = customerQueryRepository;
        }

        public async Task<AuthentResult> Login(string username, string password)
        {
            var a = await _accountQueryRepository.GetAccountByPhoneNumberAsync(username);
            //1.Kiem tra su ton tai cua tai khoan
            if (a is null)
            {
                throw new Exception("Khong ton tai tai khoan");
            }
            //2.Kiem tra mat khau
            if (a.Password != password)
            {
                throw new Exception("Mat khau khong chinh xac");
            }
            //3.Tao Jwt token
            var token = _jwtTokenGenerator.GenerateToken(a);
            var c = await _customerQueryRepository.FindByIdAsync(a.Id);
            return new AuthentResult(a.Id, a.PhoneNumber, c, a.CreatedDate, a.ModifiedDate, token);
        }
    }
}
