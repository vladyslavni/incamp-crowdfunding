using Crowdfunding.Models;
using System.Linq;
using System.Collections.Generic;

namespace Crowdfunding.Services
{
    public class TeamService
    {

        private CrowdfudingContext db;

        public TeamService(CrowdfudingContext db)
        {
            this.db = db;
        }

        public Team GetById(long id)
        {
            return db.Teams.Find(id);
        }

        public List<Team> GetAll()
        {
            return db.Teams.ToList();
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

        public void RemoveById(long id)
        {
            Team team = db.Teams.Find(id);
            db.Teams.Remove(team);
            db.SaveChanges();
        }
    }
}