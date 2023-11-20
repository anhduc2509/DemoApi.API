using DemoApi.Application.Interface.Authentication;
using DemoApi.Application.Interface.Service;
using DemoApi.Infracstructure.Data;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Infracstructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSetting _jwtSetting;
        private readonly IDateTimeProvide _dateTimeProvide;

        public JwtTokenGenerator(IOptions<JwtSetting> jwtSetting, IDateTimeProvide dateTimeProvide)
        {
            _jwtSetting = jwtSetting.Value;
            _dateTimeProvide = dateTimeProvide;
        }

        public string GenerateToken(Account account)
        {
            var signingCreditials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Secret)), SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.GivenName, account.PhoneNumber),
                new Claim(JwtRegisteredClaimNames.Jti, account.Id.ToString())
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSetting.Issuer,
                audience: _jwtSetting.Audience,
                expires: _dateTimeProvide.UtcNow.AddMinutes(_jwtSetting.ExpiryMinutes),
                claims: claims,
                signingCredentials: signingCreditials
                );
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
