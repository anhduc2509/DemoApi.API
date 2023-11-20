using DemoApi.Application.Dto;
using DemoApi.Application.Service.Commands;
using DemoApi.Application.Service.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllAccountQuery());
            return Ok(result);
        }

        [HttpGet("account")]
        public async Task<IActionResult> GetAccount([FromQuery] GetAccountByIdCommand account)
        {
            var result = await _mediator.Send(account);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<AccountDto>> CreateAccount([FromBody] CreateAccountCommand account)
        {
            var result = await _mediator.Send(account);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountCommand account)
        {
            try
            {
                var result = await _mediator.Send(account);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<AccountDto>> DeleteAccount(string id)
        {
            var result = await _mediator.Send(new DeleteAccountCommand(id));
            return Ok(result);
        }
    }
}
