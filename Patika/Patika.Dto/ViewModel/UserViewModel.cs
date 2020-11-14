using Patika.Dto.Wrapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace Patika.Dto.ViewModel
{
    [Serializable]
    public class UserViewModel: ResponseView
    {
        [Display(Description = "UserId")]
        public int UserId { get; set; }

        [Display(Description = "ProfileId")]
        public int ProfileId { get; set; }

        [Display(Description = "Kullanıcı Adı")]
        public string FullName { get; set; }

        [Display(Description = "Email Adresi")]
        public string Email { get; set; }

        [Display(Description = "Avatar")]
        public string Avatar { get; set; }

        [Display(Description = "Aktif")]
        public bool IsActive { get; set; }

        [Display(Description = "Profil Adı")]
        public string ProfileName { get; set; }

        [Display(Description = "Admin Yetkisi")]
        public bool HasAdminRights { get; set; }
    }
}