using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using CodeSavvy.Infrastructure.DataAccess;

namespace CodeSavvy.Infrastructure.Repositories
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly DatabaseContext _db;

        public EmployerRepository(DatabaseContext db)
        {
            _db = db;
        }

        public Task<Employer> CreateEmployer(Employer employer)
        {
            _db.Employers.Add(employer);
            _db.SaveChanges();
            return Task.FromResult(employer);
        }

        public Task<Employer> DeleteEmployer(int employerId)
        {
            var employer = GetEmployer(employerId).Result;
            _db.Employers.Remove(employer);
            _db.SaveChanges();
            return Task.FromResult(employer);
        }

        public Task<Employer> GetEmployer(int employerId)
        {
            var employer = _db.Employers.Find(employerId);
            return Task.FromResult(employer);
        }

        public Task<Employer> UpdateEmployer(int employerId, Employer employer)
        {
            employer.Id = employerId;
            _db.Employers.Update(employer);
            _db.SaveChanges();
            return Task.FromResult(employer);
        }
    }
}
