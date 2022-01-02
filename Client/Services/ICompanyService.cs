using CW2.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW2.Client.Services
{
    public interface ICompanyService
    {
        event Action OnChange;
        List<Company> Companies { get; set; }

        Task<List<Company>> GetCompanies();

        Task<Company> GetSingleCompany(int id);

        Task<List<Company>> CreateCompany(Company company);

        Task<List<Company>> UpdateCompany(Company company, int id);
    }
}
