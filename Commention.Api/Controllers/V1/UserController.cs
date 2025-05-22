using Commention.Application.Commands.User.CreateUser;
using Commention.Application.Commands.User.DeleteUser;
using Commention.Application.Commands.User.UpdateUser;
using Commention.Application.Queries.User.GetAllUsers;
using Commention.Application.Queries.User.GetUserById;
using Commention.Application.Queries.User.SendEmailToAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Commention.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery()));
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserById(long id)
        {
            return Ok(await _mediator.Send(new GetUserByIdQuery { Id = id }));
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SendEmailToAll(SendEmailToAllQuery query)
        {
            await _mediator.Send(query);
            return Ok();
        }
    }
}
