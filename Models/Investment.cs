using System;
using Newtonsoft.Json;

namespace Crowdfunding.Models
{
    public class Investment
    {
        public long Id { get; set; }
        public User Backer {get; set;}
        public Project Project {get; set;}
        public double Amount {get; set;}
        public DateTime Date {get; set;}
    }
}