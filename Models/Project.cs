using Crowdfunding.Models.Enums;

namespace Crowdfunding.Models
{
    public class Project
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public long Goal {get; set;}
        public Team team {get; set;}
        public ProjectStatus Status {get; set;}
    }
}