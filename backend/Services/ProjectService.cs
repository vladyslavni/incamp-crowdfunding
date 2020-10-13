using Crowdfunding.Models;
using Crowdfunding.Models.Enums;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Crowdfunding.Services
{
    public class ProjectService
    {
        private CrowdfudingContext db;

        public ProjectService(CrowdfudingContext db)
        {
            this.db = db;
        }

        public Project GetById(long id)
        {
            return db.Projects.Where(p => p.Id == id).Include(p => p.Owner).FirstOrDefault();
        }

        public List<Project> GetAll()
        {
            return db.Projects.Include(p => p.Owner).ToList();
        }

        public void UpdateCollectedMoney(long id)
        {
            double money = db.Investments.Where(inv => inv.Project.Id == id).Select(inv => inv.Amount).Sum();
            Project project = db.Projects.Find(id);

            project.CollectedMoney = money;

            db.SaveChanges();

            if (project.Goal <= project.CollectedMoney) 
            {
                UpdateStatus(id, ProjectStatus.FUNDED);
            }
            else
            {
                UpdateStatus(id, ProjectStatus.IN_PROGRESS);
            }
        }

        public void CreateNew(long userId, Project project)
        {
            User user = db.Users.Find(userId);
            project.Owner = user;

            db.Projects.Add(project);
            db.SaveChanges();
        }

        public void UpdateStatus(long id, ProjectStatus status)
        {
            Project project = db.Projects.Find(id);
            project.Status = status;
            db.SaveChanges();
        }

        public void RemoveById(long id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
        }
    }
}