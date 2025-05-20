namespace Commention.Application.Queries.Comment.GetCommentsByUserId
{
    public class GetCommentsByUserIdDto
    {
        public long Id { get; set; }
        public string? Body { get; set; }
        public bool IsConfirm { get; set; }
    }
}
