using Crowdfunding.Models;
using System.Linq;
using System.Collections.Generic;

namespace Crowdfunding.Services
{
    public class TeamService
    {

        private CrowdfudingContext db;
        private UserService userService;
        public TeamService(CrowdfudingContext db, UserService userService)
        {
            this.db = db;
            this.userService = userService;
        }

        public Team GetById(long id)
        {
            return db.Teams.Find(id);
        }

        public List<Team> GetAll()
        {
            return db.Teams.ToList();
        }

        public List<User> GetAllMembers(long id)
        {
            return db.Teams.Find(id).Members;
        }

        public void CreateNew(Team team)
        {
            db.Teams.Add(team);
            db.SaveChanges();
        }

        public void UpdateName(long id, string name)
        {
            Team team = db.Teams.Find(id);
            team.Name = name;
            db.SaveChanges();
        }

        public void AddMember(long id, long userId)
        {
            Team team = db.Teams.Find(id);
            User user = userService.GetById(userId);
            team.Members.Add(user);
            db.SaveChanges();
        }

        public void RemoveMember(long id, long userId)
        {
            Team team = db.Teams.Find(id);
            team.Members.RemoveAll(user => user.Id == userId);
            db.SaveChanges();
        }

        public void RemoveById(long id)
        {
            Team team = db.Teams.Find(id);
            db.Teams.Remove(team);
            db.SaveChanges();
        }
    }
}