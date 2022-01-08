using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Application.Exceptions.NotFoundException;
using CodeSavvy.Application.Exceptions.NullArgumentException;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using CodeSavvy.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CodeSavvy.Infrastructure.Repositories
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly DatabaseContext _db;

        public EmployerRepository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<Employer> CreateEmployer(Employer employer)
        {
            _ = employer ?? throw new EmployerNullArgumentException();
            _db.Employers.Add(employer);
            await _db.SaveChangesAsync();
            return employer;
        }

        public async Task<Employer> DeleteEmployer(int employerId)
        {
            var employer = await GetEmployer(employerId);
            _db.Employers.Remove(employer);
            await _db.SaveChangesAsync();
            return employer;
        }

        public async Task<Employer> GetEmployer(int employerId)
        {
            var employer = await _db.Employers.Include(x => x.Credentials).SingleAsync(x => x.Id == employerId) ?? 
                           throw new EmployerNotFoundException($"Employer with Id: {employerId} could not be found");
            return employer;
        }

        public async Task<Employer> GetEmployer(string email)
        {
            var employer = await _db.Employers.Include(x => x.Credentials).Where(x => x.Credentials.Email == email).FirstAsync() ??
                           throw new EmployerNotFoundException($"Employer with credential's email: {email} could not be found");
            return employer;
        }

        public async Task<Employer> UpdateEmployer(int employerId, Employer employer)
        {
            _ = employer ?? throw new EmployerNullArgumentException();
            var employerEntity = await GetEmployer(employerId);
            employerEntity.Image = employer.Image;
            employerEntity.CompanyName = employer.CompanyName;
            await _db.SaveChangesAsync();
            return employer;
        }
    }
}
