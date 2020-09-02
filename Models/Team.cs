using System.Collections.Generic;

namespace Crowdfunding.Models
{
    public class Team
    {
        public string Name {get; set;}
        public List<User> Members {get; set;}
    }
}