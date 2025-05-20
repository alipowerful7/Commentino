using Commention.Domain.Models.Entities;

namespace Commention.Domain.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAllCommentsAsync();
        Task<IEnumerable<Comment>> GetCommentsByUserIdAsync(long userId);
        Task<Comment> GetCommentByIdAsync(long idcommentId);
        Task<bool> IsCommentConfirm(long commentId);
        Task ConfirmComment(long commentId);
        Task CreateCommentAsync(Comment comment);
        Task UpdateCommentAsync(Comment comment);
        Task DeleteCommentAsync(long commentId);
    }
}
