using Crowdfunding.Models;
using Crowdfunding.Models.Dto;
using Crowdfunding.Models.Mappers;
using System.Linq;
using System.Collections.Generic;
using Crowdfunding.Utils;
using Crowdfunding.Models.Enums;
using Microsoft.EntityFrameworkCore;

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
            return db.Investments.Include(p => p.Backer).Include(p => p.Project).FirstOrDefault();
        }

        public List<Investment> GetAllByBackerID(long id)
        {
            return db.Investments.Where(inv => inv.Backer.Id.Equals(id)).Include(p => p.Backer).Include(p => p.Project).ToList();
        }

        public List<Investment> GetAllByProjectID(long id)
        {
            return db.Investments.Where(inv => inv.Project.Id == id).Include(p => p.Backer).Include(p => p.Project).ToList();
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
                throw new TransactionErrorException("Transaction execution error");
            }
        }

        public void RemoveById(long id)
        {
            Investment investment = db.Investments.Include(i => i.Project).FirstOrDefault();
            long projectId = investment.Project.Id;

            TransactionStatus transactionResult = BankService.MakeReturnTransaction(investment.Amount);

            if (transactionResult == TransactionStatus.COMPLETED)
            {
                db.Investments.Remove(investment);
                db.SaveChanges();
                
                projectService.UpdateCollectedMoney(projectId);
            } 
            else
            {
                throw new TransactionErrorException("Transaction execution error");
            }
        }
    }
}