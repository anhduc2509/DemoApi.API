using DemoApi.Application.Service.Authentication;
using DemoApi.Contracts.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [Route("v1/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentService _authentService;

        public AuthenticationController(IAuthentService authentService)
        {
            _authentService = authentService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LogIn(LoginRequest request)
        {
            var result = await _authentService.Login(request.PhoneNumber, request.Password);
            return Ok(result);
        }
    }
}
