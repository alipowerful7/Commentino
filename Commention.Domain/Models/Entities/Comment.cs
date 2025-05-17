using Commention.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Commention.Domain.Models.Entities
{
    public class Comment : BaseEntity
    {
        [Required]
        public string? Body { get; set; }
        [Required]
        public bool IsConfirm { get; set; }


        #region Relations
        public User? User { get; set; }
        public long? UserId { get; set; }
        public Comment? Replay { get; set; }
        public long? ReplayId { get; set; }
        #endregion
    }
}
