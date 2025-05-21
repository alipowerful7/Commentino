using Commention.Domain.Models.Entities;

namespace Commention.Domain.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAllCommentsAsync();
        Task<IEnumerable<Comment>> GetCommentsByUserIdAsync(long userId);
        Task<Comment> GetCommentByIdAsync(long commentId);
        Task<bool> IsCommentConfirm(long commentId);
        Task<bool> IsUserCanDeleteComment(long commentId, long userId);
        Task ConfirmComment(long commentId);
        Task CreateCommentAsync(Comment comment);
        Task UpdateCommentAsync(Comment comment);
        Task DeleteCommentAsync(long commentId);
    }
}
