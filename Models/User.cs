using Microsoft.AspNetCore.Identity;

namespace Crowdfunding.Models
{
    public class User :IdentityUser<long>
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
    }
}