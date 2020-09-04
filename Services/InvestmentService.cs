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
        public InvestmentService(CrowdfudingContext db, UserService userService, ProjectService projectService)
        {
            this.db = db;
            this.userService = userService;
            this.projectService = projectService;
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
            
            TransactionStatus transactionResult = BankService.MakeTransaction(investmentDto.Amount);

            if(transactionResult == TransactionStatus.COMPLETED)
            {
                Investment investment = InvestmentMapper.Map(user, project, investmentDto);
                
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
            
            TransactionStatus transactionResult = BankService.MakeReturnTransaction(investment.Amount);

            if (transactionResult == TransactionStatus.COMPLETED)
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