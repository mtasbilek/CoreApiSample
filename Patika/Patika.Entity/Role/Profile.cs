using Patika.Entity.Authentication;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patika.Entity.Role
{
    [Table("Profiles")]
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(128)]
        public string Name { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}