using DH.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace DH.Entities.Entities
{
    public class Mail : BaseEntity, IEntity
    {
        [Key]
        public int MailId { get; set; }

        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Ad soyad zorunludur")]
        public string FullName { get; set; }

        [Display(Name = "Email Adresi")]
        [Required(ErrorMessage = "Eposta adresi zorunludur")]
        [EmailAddress(ErrorMessage = "Geçersiz mail adresi")]
        public string MailAddress { get; set; }

        [Display(Name = "Konu")]
        [Required(ErrorMessage = "Konu zorunludur")]
        public string Subject { get; set; }

        [Display(Name = "Mesaj")]
        [Required(ErrorMessage = "Mesaj zorunludur")]
        public string Body { get; set; }
    }
}
