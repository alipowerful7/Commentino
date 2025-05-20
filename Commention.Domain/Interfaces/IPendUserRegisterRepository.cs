using Commention.Domain.Models.Entities;

namespace Commention.Domain.Interfaces
{
    public interface IPendUserRegisterRepository
    {
        Task<PendUserRegister> GetPendUserRegisterByIdAsync(long pendUserRegisterId);
        Task<bool> IsPendUserRegisterExistsAsync(string userName, string email);
        Task CreatePendUserRegisterAsync(PendUserRegister pendUserRegister);
        Task DeletePendUserRegisterAsync(long pendUserRegisterId);
        Task UpdatePendUserRegisterAsync(PendUserRegister pendUserRegister);
    }
}
