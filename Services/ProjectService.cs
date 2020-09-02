using Crowdfunding.Models;
using Crowdfunding.Models.Enums;
using System.Linq;
using System.Collections.Generic;

namespace Crowdfunding.Services
{
    public class ProjectService
    {
        public Project GetById(long id)
        {
            using(CrowdfudingContext db = new CrowdfudingContext()) 
            {
                return db.Projects.Find(id);
            }
        }

        public List<Project> GetAll()
        {
            using(CrowdfudingContext db = new CrowdfudingContext()) 
            {
                return db.Projects.ToList();
            }
        }

        public void CreateNew(Project project)
        {
            using(CrowdfudingContext db = new CrowdfudingContext()) 
            {
                db.Projects.Add(project);
                db.SaveChanges();
            }
        }

        public void UpdateStatus(long id, ProjectStatus status)
        {
            using(CrowdfudingContext db = new CrowdfudingContext()) 
            {
                Project project = db.Projects.Find(id);
                project.Status = status;
                db.SaveChanges();
            }
        }

        public void RemoveById(long id)
        {
            using(CrowdfudingContext db = new CrowdfudingContext()) 
            {
                Project project = db.Projects.Find(id);
                db.Projects.Remove(project);
                db.SaveChanges();
            }
        }
    }
}