using Crowdfunding.Models;
using System.Linq;
using System.Collections.Generic;

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