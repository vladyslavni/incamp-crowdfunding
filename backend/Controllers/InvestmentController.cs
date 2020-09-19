using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Crowdfunding.Models;
using Crowdfunding.Services;
using Microsoft.AspNetCore.Http;
using Crowdfunding.Models.Dto;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Crowdfunding.Controllers
{
    [ApiController]
    [Route("api/")]
    public class InvestmentController : Controller
    {
        private InvestmentService investmentService;

        public InvestmentController(InvestmentService investmentsService)
        {
            this.investmentService = investmentsService;
        }

        [HttpGet("investments/{id}")]
        public Investment GetInvestmentById(long id)
        {
            return investmentService.GetById(id);
        }

        [HttpGet("users/{id}/investments")]
        public List<Investment> GetAllInvestmentsByBackerID(long id)
        {
            return investmentService.GetAllByBackerID(id);
        }

        [HttpGet("users/me/investments")]
        public List<Investment> GetAllMyInvestments()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            long userId = Int64.Parse(id);

            return investmentService.GetAllByBackerID(userId);
        }

        [HttpGet("projects/{id}/investments")]
        public List<Investment> GetAllInvestmentsByProjectID(long id)
        {
            return investmentService.GetAllByProjectID(id);
        }

        [HttpPost("projects/{projectId}/investments")]
        public void CreateNewInvestment(long projectId, InvestmentDto investmentDto)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            long userId = Int64.Parse(id);

            investmentService.CreateNew(userId, projectId, investmentDto);
        }

        [HttpDelete("investments/{id}")]
        public void RemoveInvestmentById(long id)
        {
            investmentService.RemoveById(id);
        }
    }
}