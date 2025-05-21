using Commention.Domain.Interfaces;
using Commention.Domain.Models.Entities;
using Commention.Domain.Models.Enums;
using Commention.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Commention.Infrastructure.Persistence.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepository;

        public CommentRepository(ApplicationDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public async Task ConfirmComment(long commentId)
        {
            var model = await GetCommentByIdAsync(commentId);
            model.IsConfirm = true;
            await UpdateCommentAsync(model);
        }

        public async Task CreateCommentAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(long commentId)
        {
            var model = await GetCommentByIdAsync(commentId);
            _context.Comments.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync()
        {
            return await _context.Comments.Include(c => c.User).OrderBy(c => c.CreateDate).ToListAsync();
        }

        public async Task<Comment> GetCommentByIdAsync(long commentId)
        {
            var model = await _context.Comments.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == commentId);
            if (model == null)
            {
                throw new Exception("کامنت پیدا نشد.");
            }
            return model;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByUserIdAsync(long userId)
        {
            return await _context.Comments.Where(c => c.UserId == userId).Include(c => c.User).OrderBy(c => c.CreateDate).ToListAsync();
        }

        public async Task<bool> IsCommentConfirm(long commentId)
        {
            var model = await GetCommentByIdAsync(commentId);
            return model.IsConfirm;
        }

        public async Task<bool> IsUserCanDeleteComment(long commentId, long userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            var comment = await GetCommentByIdAsync(commentId);
            if (comment.UserId == user.Id || user.UserRole == UserRole.Admin)
            {
                return true;
            }
            return false;
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
        }
    }
}
