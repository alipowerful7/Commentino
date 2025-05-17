using Commention.Domain.Models.Entities;

namespace Commention.Domain.Interfaces
{
    public interface IPendUserRegisterRepository
    {
        Task<PendUserRegister> GetPendUserRegisterByIdAsync(long id);
        Task ConfirmEmailAsync(long id, string confirmCode);
        Task<long> CreatePendUserRegisterAsync(PendUserRegister pendUserRegister);
        Task DeletePendUserRegisterAsync(long id);
    }
}
