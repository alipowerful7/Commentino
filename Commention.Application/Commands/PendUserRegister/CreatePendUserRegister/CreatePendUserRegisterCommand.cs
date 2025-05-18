using MediatR;

namespace Commention.Application.Commands.PendUserRegister.CreatePendUserRegister
{
    public class CreatePendUserRegisterCommand : IRequest<long>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
