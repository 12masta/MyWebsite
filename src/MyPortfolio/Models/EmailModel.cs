using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class EmailModel
    {
        [Required, Display(Name= "Your name")]
        public string FromName { get; set; }
        [Required, Display(Name = "Your Email"), EmailAddress]
        public string FromEmail { get; set; }
        [Required, Display(Name = "Subject")]
        public string Subject { get; set; }
        [Required, Display(Name = "Message")]
        public string Message { get; set; }
    }
}
