using Commention.Domain.Models.Entities;

namespace Commention.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
