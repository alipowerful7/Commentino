using Commention.Domain.Models.Entities;

namespace Commention.Domain.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAllCommentsAsync();
        Task<IEnumerable<Comment>> GetCommentsByUserIdAsync(long userId);
        Task<Comment> GetCommentByIdAsync(long id);
        Task ConfirmComment(long id);
        Task AddCommentAsync(Comment comment);
        Task UpdateCommentAsync(Comment comment);
        Task DeleteCommentAsync(long id);
    }
}
