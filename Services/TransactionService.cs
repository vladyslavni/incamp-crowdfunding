using Crowdfunding.Models;
using Crowdfunding.Models.Enums;
using Crowdfunding.Models.Dto;
using Crowdfunding.Models.Mappers;

namespace Crowdfunding.Services
{
    public class TransactionService
    {
        private CrowdfudingContext db;

        public TransactionService(CrowdfudingContext db)
        {
            this.db = db;
        }

        public TransactionResult GetById(long id)
        {
            return db.Transactions.Find(id);
        }

        public void SaveNew(TransactionResult transaction)
        {
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
    }
}