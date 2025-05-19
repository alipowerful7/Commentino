namespace Commention.Application.Queries.User.GetAllUsers
{
    public class GetAllUsersDto
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? UserRole { get; set; }

    }
}
