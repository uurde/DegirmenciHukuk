using DH.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace DH.Entities.Entities
{
    public class User: BaseEntity, IEntity
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Zorunlu")]
        public string Username { get; set; }

        [Display(Name = "Kullanıcı Şifresi")]
        [Required(ErrorMessage = "Zorunlu")]
        public string UserPassword { get; set; }

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Zorunlu")]
        public string FirstName { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Zorunlu")]
        public string LastName { get; set; }

        [Display(Name = "Kullanıcı Resmi")]
        public string UserPhotoPath { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }
    }
}
