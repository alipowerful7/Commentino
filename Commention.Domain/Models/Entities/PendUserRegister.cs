using Commention.Domain.Common;

namespace Commention.Domain.Models.Entities
{
    public class PendUserRegister : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? ConfirmCode { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
