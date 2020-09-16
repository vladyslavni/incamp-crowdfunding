using Crowdfunding.Models.Dto;
using Crowdfunding.Models;

namespace Crowdfunding.Models.Mappers
{
    public class RegisterUserMapper
    {
        public static User Map(RegisterUserDto userDto)
        {
            User user = new User{};

            user.UserName = userDto.UserName;
            user.NormalizedUserName = userDto.UserName.ToUpper();
            user.Email = userDto.Email;
            user.NormalizedEmail = userDto.Email.ToUpper();
            user.PhoneNumber = userDto.PhoneNumber;
            user.PasswordHash = userDto.PasswordHash;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.EmailConfirmed = true;
            user.LockoutEnabled = true;

            return user;
        }
    }
}