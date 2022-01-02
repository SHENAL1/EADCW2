using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CW2.Shared;


namespace CW2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        static List<Company> companies = new List<Company>
        {
            new Company { CompanyId= 1, CompanyName = "ABC Company", CompanyAddress="Colombo 4", CompanyEmail ="abc@gmail.com", CompanyPhoneNo = "0112956234", CompanyDescription = "Software Company"},
            new Company { CompanyId= 2, CompanyName = "Logic Company",  CompanyAddress="Colombo 7", CompanyEmail ="logic@gmail.com", CompanyPhoneNo = "0112956235", CompanyDescription = "Software Company"}
        };

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleCompany(int id)
        {
            var company = companies.FirstOrDefault(c => c.CompanyId == id);
            if(company == null)
            {
                return NotFound("The Company is not in the system");
            }
            else
            {
                return Ok(company);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(Company company)
        {
            company.CompanyId = companies.Max(c => c.CompanyId + 1);
            companies.Add(company);

            return Ok(companies);
         
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(Company company, int id)
        {
            var dbCompany = companies.FirstOrDefault(c => c.CompanyId == id);
            if (dbCompany == null)
            {
                return NotFound("The Company is not in the system");
            }

            var indexCompany = companies.IndexOf(dbCompany);
            companies[indexCompany] = company;

            return Ok(companies);


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var dbCompany = companies.FirstOrDefault(c => c.CompanyId == id);
            if (dbCompany == null)
            {
                return NotFound("The Company is not in the system");
            }

            companies.Remove(dbCompany);

            return Ok(companies);


        }
    }
}
