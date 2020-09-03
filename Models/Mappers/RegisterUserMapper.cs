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
            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber;
            user.PasswordHash = userDto.PasswordHash;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;

            return user;
        }
    }
}