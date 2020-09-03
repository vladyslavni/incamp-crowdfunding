using Crowdfunding.Models;
using Crowdfunding.Models.Dto;
using System.Linq;
using System.Collections.Generic;
using Extension;
using Crowdfunding.Models.Mappers;

namespace Crowdfunding.Services
{
    public class UserService
    {
        private CrowdfudingContext db;

        public UserService(CrowdfudingContext db)
        {
            this.db = db;
        }

        public User GetById(long id)
        {
            return db.Users.Find(id);
        }
        
        public User GetByCredentials(LoginUserDto user)
        {
            if (user.Login.IsPhone())
            {
                return db.Users.Where(u => u.PhoneNumber.Equals(user.Login) && u.PasswordHash.Equals(user.PasswordHash)).FirstOrDefault();
            } 
            else if (user.Login.IsMail())
            {
                return db.Users.Where(u => u.Email.Equals(user.Login) && u.PasswordHash.Equals(user.PasswordHash)).FirstOrDefault();
            }
            else 
            {
                return db.Users.Where(u => u.UserName.Equals(user.Login) && u.PasswordHash.Equals(user.PasswordHash)).FirstOrDefault();
            }
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public void CreateNew(RegisterUserDto userDto)
        {
            User user = RegisterUserMapper.Map(userDto);
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void RemoveById(long id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}