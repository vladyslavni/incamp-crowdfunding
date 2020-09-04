using System;
using Crowdfunding.Models.Dto;

namespace Crowdfunding.Models.Mappers
{
    public class InvestmentMapper
    {
        public static Investment Map(User user, Project project, TransactionResult transaction)
        {
            Investment investment = new Investment();
            
            investment.Backer = user;
            investment.Project = project;
            investment.Amount = transaction.Amount;
            investment.Date = DateTime.Now;
            investment.Transaction = transaction;

            return investment;
        }
    }
}