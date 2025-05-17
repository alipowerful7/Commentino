using Commention.Domain.Common;
using Commention.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Commention.Domain.Models.Entities
{
    public class User : BaseEntity
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


        #region Relations
        [Required]
        public UserRole UserRole { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        #endregion
    }
}
