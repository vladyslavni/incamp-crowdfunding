using Crowdfunding.Models;
using Crowdfunding.Models.Enums;
using System.Linq;
using System.Collections.Generic;

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
            return db.Projects.Find(id);
        }

        public List<Project> GetAll()
        {
            return db.Projects.ToList();
        }

        public void UpdateCollectedMoney(long id)
        {
            double money = db.Investments.Where(inv => inv.Project.Id == id).Select(inv => inv.Amount).Sum();

            db.Projects.Find(id).CollectedMoney = money;
            db.SaveChanges();
        }

        public void CreateNew(Project project)
        {
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