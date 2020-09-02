using Crowdfunding.Models;
using System.Linq;
using System.Collections.Generic;

namespace Crowdfunding.Services
{
    public class UserService
    {
        public User GetById(int id)
        {
            using(CrowdfudingContext db = new CrowdfudingContext()) 
            {
                return db.Users.Find(id);
            }
        }

        public List<User> GetAll()
        {
            using(CrowdfudingContext db = new CrowdfudingContext()) 
            {
                return db.Users.ToList();
            }
        }

        public void CreateNew(User user)
        {
            using(CrowdfudingContext db = new CrowdfudingContext()) 
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void RemoveById(int id)
        {
            using(CrowdfudingContext db = new CrowdfudingContext()) 
            {
                User user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
    }
}