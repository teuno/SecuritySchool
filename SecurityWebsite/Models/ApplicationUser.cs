using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SecurityWebsite.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required] public bool Active { get; set; }
    }
}