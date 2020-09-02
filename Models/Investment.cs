using System;
namespace Crowdfunding.Models
{
    public class Investment
    {
        public User Backer {get; set;}
        public Project Project {get; set;}
        public long Amount {get; set;}
        public DateTime Date {get; set;}
    }
}