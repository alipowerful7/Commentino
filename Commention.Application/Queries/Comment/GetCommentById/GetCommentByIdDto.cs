namespace Commention.Application.Queries.Comment.GetCommentById
{
    public class GetCommentByIdDto
    {
        public string? Body { get; set; }
        public bool IsConfirm { get; set; }
        public string? UserName { get; set; }
    }
}
