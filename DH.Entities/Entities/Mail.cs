using DH.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace DH.Entities.Entities
{
    public class Mail: BaseEntity, IEntity
    {
        [Key]
        public int MailId { get; set; }

        [Required(ErrorMessage = "Ad soyad zorunludur")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Eposta adresi zorunludur")]
        [EmailAddress(ErrorMessage = "Geçersiz mail adresi")]
        public string MailAddress { get; set; }

        [Required(ErrorMessage ="Konu zorunludur")]
        public string Subject { get; set; }


        [Required(ErrorMessage = "Mesaj zorunludur")]
        public string Body { get; set; }
    }
}
