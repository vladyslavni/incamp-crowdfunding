using System;
using Crowdfunding.Models.Dto;

namespace Crowdfunding.Models.Mappers
{
    public class InvestmentMapper
    {
        public static Investment Map(User user, Project project, InvestmentDto investmentDto)
        {
            Investment investment = new Investment();
            
            investment.Backer = user;
            investment.Project = project;
            investment.Amount = investmentDto.Amount;
            investment.Date = DateTime.Now;

            return investment;
        }
    }
}