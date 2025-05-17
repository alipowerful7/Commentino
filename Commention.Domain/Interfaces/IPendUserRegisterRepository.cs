using Commention.Domain.Models.Entities;

namespace Commention.Domain.Interfaces
{
    public interface IPendUserRegisterRepository
    {
        Task ConfirmEmailAsync(long id, string confirmCode);
        Task<PendUserRegister> GetPendUserRegisterByIdAsync(long id);
        Task<long> AddPendUserRegisterAsync(PendUserRegister pendUserRegister);
        Task DeletePendUserRegisterAsync(long id);
    }
}
