namespace Crowdfunding.Models.Dto
{
    public class UserInvestmentDto
    {
        public long InvestmentId {get; set;}
        public long UserId {get; set;}
        public string UserName {get; set;}
        public string UserAvatar {get; set;}
        public long ProjectId {get; set;}
        public string ProjectName {get; set;}
        public double InvestmentAmount {get; set;} 

    }
}