using System.ComponentModel.DataAnnotations;

namespace DegirmenciHukuk.Models
{
    public class MailModel
    {
        [Required(ErrorMessage = "Ad soyad zorunludur")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Eposta adresi zorunludur")]
        [EmailAddress(ErrorMessage = "Geçersiz mail adresi")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Konu zorunludur")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Mesaj zorunludur")]
        public string Body { get; set; }
    }
}
