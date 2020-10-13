using Microsoft.AspNetCore.Identity;

namespace Crowdfunding.Models
{   
    public class CrowdfundingPasswordHasher : IPasswordHasher<User>
    {
        public string HashPassword(User user, string password)
        {
            return password;
        }

        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
        {
            return hashedPassword.Equals(providedPassword) ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }
    }
}