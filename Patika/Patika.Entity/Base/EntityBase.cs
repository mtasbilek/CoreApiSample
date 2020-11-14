using Patika.Entity.Authentication;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patika.Entity.Base
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CreatedBy")]
        public int CreatedById { get; set; }

        [ForeignKey("UpdatedBy")]
        public int? UpdatedById { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }
    }
}
