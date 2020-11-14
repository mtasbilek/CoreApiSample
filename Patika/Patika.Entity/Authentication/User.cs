using Patika.Entity.Role;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patika.Entity.Authentication
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required,DataType(DataType.EmailAddress), MaxLength(128)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password), MaxLength(512)]
        public string Password { get; set; }

        [Required, MaxLength(128)]
        public string Name { get; set; }

        [Required, MaxLength(128)]
        public string Surname { get; set; }

        [MaxLength(512)]
        public string Avatar { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        [ForeignKey("Profile")]
        public int ProfileId { get; set; }

        public string CreatedByEmail { get; set; }
        public string UpdatedByEmail { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public bool HasAdminRights { get; set; }

        public virtual Profile Profile { get; set; }
    }
}