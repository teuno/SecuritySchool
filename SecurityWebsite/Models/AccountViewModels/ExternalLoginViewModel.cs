using System.ComponentModel.DataAnnotations;

namespace SecurityWebsite.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required] [EmailAddress] public string Email { get; set; }
    }
}