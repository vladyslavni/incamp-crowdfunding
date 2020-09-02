using Crowdfunding.Models;
using System.Linq;
using System.Collections.Generic;

namespace Crowdfunding.Services
{
    public class InvestmentService
    {
        public Investment GetById(long id)
        {
            using(CrowdfudingContext db = new CrowdfudingContext()) 
            {
                return db.Investments.Find(id);
            }
        }

        public List<Investment> GetAllByBackerID(long id)
        {
            using(CrowdfudingContext db = new CrowdfudingContext()) 
            {
                return db.Investments.Where(inv => inv.Backer.ID == id).ToList();
            }
        }

        public List<Investment> GetAllByProjectID(long id)
        {
            using(CrowdfudingContext db = new CrowdfudingContext()) 
            {
                return db.Investments.Where(inv => inv.Project.ID == id).ToList();
            }
        }

        public void CreateNew(Investment investment)
        {
            using(CrowdfudingContext db = new CrowdfudingContext()) 
            {
                db.Investments.Add(investment);
                db.SaveChanges();
            }
        }

        public void RemoveById(long id)
        {
            using(CrowdfudingContext db = new CrowdfudingContext()) 
            {
                Investment investment = db.Investments.Find(id);
                db.Investments.Remove(investment);
                db.SaveChanges();
            }
        }
    }
}