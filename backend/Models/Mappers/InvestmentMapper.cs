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

        public static UserInvestmentDto Map(Investment investment)
        {
            UserInvestmentDto investmentDto = new UserInvestmentDto();
            
            investmentDto.InvestmentId = investment.Id;
            investmentDto.UserId = investment.Backer.Id;
            investmentDto.UserName = investment.Backer.FirstName + " " + investment.Backer.LastName;
            investmentDto.UserAvatar = "";
            investmentDto.ProjectId = investment.Project.Id;
            investmentDto.ProjectName = investment.Project.Name;
            investmentDto.InvestmentAmount = investment.Amount;

            return investmentDto;
        }
    }
}