using Crowdfunding.Models;
using System.Linq;
using System.Collections.Generic;

namespace Crowdfunding.Services
{
    public class InvestmentService
    {
        private CrowdfudingContext db;

        public InvestmentService(CrowdfudingContext db)
        {
            this.db = db;
        }

        public Investment GetById(long id)
        {
            return db.Investments.Find(id);
        }

        public List<Investment> GetAllByBackerID(long id)
        {
            return db.Investments.Where(inv => inv.Backer.ID == id).ToList();
        }

        public List<Investment> GetAllByProjectID(long id)
        {
            return db.Investments.Where(inv => inv.Project.ID == id).ToList();
        }

        public void CreateNew(Investment investment)
        {
            db.Investments.Add(investment);
            db.SaveChanges();
        }

        public void RemoveById(long id)
        {
            Investment investment = db.Investments.Find(id);
            db.Investments.Remove(investment);
            db.SaveChanges();
        }
    }
}