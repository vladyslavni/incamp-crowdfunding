using Crowdfunding.Models;
using Crowdfunding.Models.Dto;
using Crowdfunding.Models.Mappers;
using System.Linq;
using System.Collections.Generic;
using Crowdfunding.Utils;
using Crowdfunding.Models.Enums;

namespace Crowdfunding.Services
{
    public class InvestmentService
    {
        private CrowdfudingContext db;
        private UserService userService;
        private ProjectService projectService;
        private TransactionService transactionService;
        public InvestmentService(CrowdfudingContext db, UserService userService, ProjectService projectService, TransactionService transactionService)
        {
            this.db = db;
            this.userService = userService;
            this.projectService = projectService;
            this.transactionService = transactionService;
        }

        public Investment GetById(long id)
        {
            return db.Investments.Find(id);
        }

        public List<Investment> GetAllByBackerID(long id)
        {
            return db.Investments.Where(inv => inv.Backer.Id.Equals(id)).ToList();
        }

        public List<Investment> GetAllByProjectID(long id)
        {
            return db.Investments.Where(inv => inv.Project.Id == id).ToList();
        }

        public void CreateNew(long userId, long projectId, InvestmentDto investmentDto)
        {
            User user = userService.GetById(userId);
            Project project = projectService.GetById(projectId);
            
            BankTransaction bankTransaction = BankTransactionMapper.Map(investmentDto);
            TransactionResult transaction = BankService.MakeTransaction(bankTransaction);

            transactionService.SaveNew(transaction);

            if(transaction.Status == TransactionStatus.COMPLETED)
            {
                Investment investment = InvestmentMapper.Map(user, project, transaction);
                
                db.Investments.Add(investment);
                db.SaveChanges();

                projectService.UpdateCollectedMoney(projectId);
            } 
            else
            {
                // TODO: Error message
            }
        }

        public void RemoveById(long id)
        {
            Investment investment = db.Investments.Find(id);
            TransactionResult transaction = investment.Transaction;
            
            BankTransaction bankTransaction = BankTransactionMapper.Map(transaction);
            TransactionResult transactionResult = BankService.MakeReturnTransaction(bankTransaction);

            transactionService.SaveNew(transactionResult);

            if (transactionResult.Status == TransactionStatus.COMPLETED)
            {
                db.Investments.Remove(investment);
                db.SaveChanges();
                
                projectService.UpdateCollectedMoney(investment.Project.Id);
            } 
            else
            {
                // TODO: Error message
            }
        }
    }
}