﻿namespace Commention.Application.Queries.User.GetUserById
{
    public class GetUserByIdDto
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? UserRole { get; set; }
    }
}
