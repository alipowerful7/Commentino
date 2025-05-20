using Commention.Application.Commands.Comment.ConfirmComment;
using Commention.Application.Commands.Comment.CreateComment;
using Commention.Application.Commands.Comment.DeleteComment;
using Commention.Application.Commands.Comment.UpdateComment;
using Commention.Application.Queries.Comment.GetAllComments;
using Commention.Application.Queries.Comment.GetCommentById;
using Commention.Application.Queries.Comment.GetCommentsByUserId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Commention.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("confirm-comment")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ConfirmComment(ConfirmCommentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPost("create-comment")]
        [Authorize]
        public async Task<IActionResult> CreateComment(CreateCommentCommand command)
        {
            var userId = long.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
            command.UserId = userId;
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteComment(DeleteCommentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateComment(UpdateCommentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("get-all-comments")]
        public async Task<IActionResult> GetAllComments()
        {
            return Ok(await _mediator.Send(new GetAllCommentsQuery()));
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCommentById(long id)
        {
            return Ok(await _mediator.Send(new GetCommentByIdQuery { Id = id }));
        }
        [HttpGet("get-comments-by-user-id")]
        [Authorize]
        public async Task<IActionResult> GetCommentsByUserId()
        {
            var userId = long.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
            return Ok(await _mediator.Send(new GetCommentsByUserIdQuery { UserId = userId }));
        }
    }
}
