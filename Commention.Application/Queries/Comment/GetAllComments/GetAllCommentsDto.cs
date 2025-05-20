namespace Commention.Application.Queries.Comment.GetAllComments
{
    public class GetAllCommentsDto
    {
        public long Id { get; set; }
        public string? Body { get; set; }
        public bool IsConfirm { get; set; }
        public long? UserId { get; set; }
        public long? ReplayId { get; set; }
        public string? UserName { get; set; }

        // این لیست برای ساختار درختی در DTO است
        public List<GetAllCommentsDto> Replies { get; set; } = new List<GetAllCommentsDto>();
    }
}
