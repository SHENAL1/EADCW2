using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CW2.Shared;
using CW2.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace CW2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        //static List<Company> companies = new List<Company>
        //{
        //    new Company { CompanyId= 1, CompanyName = "ABC Company", CompanyAddress="Colombo 4", CompanyEmail ="abc@gmail.com", CompanyPhoneNo = "0112956234", CompanyDescription = "Software Company"},
        //    new Company { CompanyId= 2, CompanyName = "Logic Company",  CompanyAddress="Colombo 7", CompanyEmail ="logic@gmail.com", CompanyPhoneNo = "0112956235", CompanyDescription = "Software Company"}
        //};
        private readonly ApplicationDbContext _context;

        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<List<Company>> GetDbCompanies()
        {
            return await _context.Companies.ToListAsync();
        }


        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            return base.Ok(await GetDbCompanies());
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleCompany(int id)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == id);

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
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return Ok(await GetDbCompanies());
         
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(Company company, int id)
        {
            var dbCompany = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == id);
            if (dbCompany == null)
            {
                return NotFound("The Company is not in the system");
            }

            dbCompany.CompanyId = company.CompanyId;
            dbCompany.CompanyName = company.CompanyName;
            dbCompany.CompanyAddress = company.CompanyAddress;
            dbCompany.CompanyEmail = company.CompanyEmail;
            dbCompany.CompanyPhoneNo = company.CompanyPhoneNo;
            dbCompany.CompanyDescription = company.CompanyDescription;

            await _context.SaveChangesAsync();
            return Ok(await GetDbCompanies());


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var dbCompany = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == id);
            if (dbCompany == null)
            {
                return NotFound("The Company is not in the system");
            }

            _context.Companies.Remove(dbCompany);
            await _context.SaveChangesAsync();
            return Ok(await GetDbCompanies());


        }
    }
}
