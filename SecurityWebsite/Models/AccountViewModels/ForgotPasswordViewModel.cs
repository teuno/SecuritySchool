using System.ComponentModel.DataAnnotations;

namespace SecurityWebsite.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required] [EmailAddress] public string Email { get; set; }
    }
}