using Commention.Domain.Models.Entities;

namespace Commention.Domain.Interfaces
{
    public interface IPendUserRegisterRepository
    {
        Task<PendUserRegister> GetPendUserRegisterByIdAsync(long id);
        Task<bool> IsPendUserRegisterExistsAsync(string userName, string email);
        Task<long> CreatePendUserRegisterAsync(PendUserRegister pendUserRegister);
        Task DeletePendUserRegisterAsync(long id);
    }
}
