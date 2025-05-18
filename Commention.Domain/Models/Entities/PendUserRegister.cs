using Commention.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Commention.Domain.Models.Entities
{
    public class PendUserRegister : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(200)]
        public string? LastName { get; set; }
        [Required]
        [MaxLength(150)]
        public string? Email { get; set; }
        [Required]
        [MaxLength(150)]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [MaxLength(100)]
        public string? ConfirmCode { get; set; }
        [Required]
        public DateTime ExpireDate { get; set; }
    }
}
