using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;

namespace CodeSavvy.Domain.Interfaces
{
    public interface IEmployerRepository
    {
        Task<Employer> CreateEmployer(Employer employer);
        Task<Employer> DeleteEmployer(int employerId);
        Task<Employer> GetEmployer(int employerId);
        Task<Employer> GetEmployer(string email);
        Task<Employer> UpdateEmployer(int employerId, Employer employer);
    }
}
