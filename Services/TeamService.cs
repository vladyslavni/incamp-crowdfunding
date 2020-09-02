using Crowdfunding.Models;
using System.Linq;
using System.Collections.Generic;

namespace Crowdfunding.Services
{
    public class TeamService
    {
        public Team GetById(int id)
        {
            using(CrowdfudingContext db = new CrowdfudingContext()) 
            {
                return db.Teams.Find(id);
            }
        }

        public List<Team> GetAll()
        {
            using(CrowdfudingContext db = new CrowdfudingContext()) 
            {
                return db.Teams.ToList();
            }
        }

        public void CreateNew(Team team)
        {
            using(CrowdfudingContext db = new CrowdfudingContext()) 
            {
                db.Teams.Add(team);
                db.SaveChanges();
            }
        }

        public void UpdateName(int id, string name)
        {
            using(CrowdfudingContext db = new CrowdfudingContext()) 
            {
                Team team = db.Teams.Find(id);
                team.Name = name;
                db.SaveChanges();
            }
        }

        public void RemoveById(int id)
        {
            using(CrowdfudingContext db = new CrowdfudingContext()) 
            {
                Team team = db.Teams.Find(id);
                db.Teams.Remove(team);
                db.SaveChanges();
            }
        }
    }
}