using Commention.Domain.Interfaces;
using Commention.Domain.Models.Entities;
using Commention.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Commention.Infrastructure.Persistence.Repositories
{
    public class PendUserRegisterRepository : IPendUserRegisterRepository
    {
        private readonly ApplicationDbContext _context;

        public PendUserRegisterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreatePendUserRegisterAsync(PendUserRegister pendUserRegister)
        {
            await _context.PendUserRegisters.AddAsync(pendUserRegister);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePendUserRegisterAsync(long pendUserRegisterId)
        {
            var model = await GetPendUserRegisterByIdAsync(pendUserRegisterId);
            _context.PendUserRegisters.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<PendUserRegister> GetPendUserRegisterByIdAsync(long pendUserRegisterId)
        {
            var model = await _context.PendUserRegisters.FirstOrDefaultAsync(p => p.Id == pendUserRegisterId);
            if (model == null)
            {
                throw new Exception("کاربر پیدا نشد.");
            }
            return model;
        }

        public async Task<bool> IsPendUserRegisterExistsAsync(string userName, string email)
        {
            return await _context.PendUserRegisters.AnyAsync(p => p.UserName == userName || p.Email == email);
        }
    }
}
