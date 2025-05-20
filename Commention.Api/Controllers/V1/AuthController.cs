using Commention.Application.Commands.PendUserRegister.ConfirmEmail;
using Commention.Application.Commands.PendUserRegister.CreatePendUserRegister;
using Commention.Application.Commands.PendUserRegister.ReSendConfirmEmail;
using Commention.Application.Queries.User.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Commention.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreatePendUserRegisterCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPost("resend-confirm-email")]
        public async Task<IActionResult> ReSendConfirmEmail(ReSendConfirmEmailCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
