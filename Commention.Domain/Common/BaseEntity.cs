using System.ComponentModel.DataAnnotations;

namespace Commention.Domain.Common
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
