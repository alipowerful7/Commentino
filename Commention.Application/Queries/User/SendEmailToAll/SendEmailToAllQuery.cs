using MediatR;

namespace Commention.Application.Queries.User.SendEmailToAll
{
    public class SendEmailToAllQuery : IRequest
    {
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}
