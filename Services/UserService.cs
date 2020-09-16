using System;
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
        
        public User GetByCredentials(LoginUserDto userDto)
        {
            if (userDto.Login.IsPhoneNumber())
            {
                return db.Users.Where(u => u.PhoneNumber.Equals(userDto.Login)).FirstOrDefault();
            } 
            else if (userDto.Login.IsEmail())
            {
                return db.Users.Where(u => u.Email.Equals(userDto.Login)).FirstOrDefault();
            }
            else 
            {
                return db.Users.Where(u => u.UserName.Equals(userDto.Login)).FirstOrDefault();
            }
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public void CreateNew(User user)
        {
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