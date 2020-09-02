using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Crowdfunding.Models;
using Crowdfunding.Services;

namespace Crowdfunding.Controllers
{
    [ApiController]
    [Route("api/d")]
    public class InvestmentController : Controller
    {
        private InvestmentService investmentService;

        public InvestmentController(InvestmentService investmentsService)
        {
            this.investmentService = investmentsService;
        }

        [HttpGet("investments/{id}")]
        public Investment GetInvestmentById(int id)
        {
            return investmentService.GetById(id);
        }

        [HttpGet("backers/{id}/investments/")]
        public List<Investment> GetAllInvestmentsByBackerID(int id)
        {
            return investmentService.GetAllByBackerID(id);
        }

        [HttpGet("projects/{id}/investments/")]
        public List<Investment> GetAllInvestmentsByProjectID(int id)
        {
            return investmentService.GetAllByProjectID(id);
        }

        [HttpPost("investments/")]
        public void CreateNewInvestment(Investment investment)
        {
            investmentService.CreateNew(investment);
        }

        [HttpDelete("investments/{id}")]
        public void RemoveInvestmentById(int id)
        {
            investmentService.RemoveById(id);
        }
    }
}