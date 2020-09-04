using Crowdfunding.Models.Enums;
using System.Collections.Generic;

namespace Crowdfunding.Models
{
    public class Project
    {
        public long Id { get; set; }
        public string Name {get; set;}
        public string Description {get; set;}
        public long Goal {get; set;}
        public double CollectedMoney {get; set;}
        public Team Team {get; set;}
        public ProjectStatus Status {get; set;}
    }
}