using System;
using System.ComponentModel.DataAnnotations;

namespace Lunatech.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
