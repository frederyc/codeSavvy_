using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.DataAccess;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;

namespace CodeSavvy.Infrastructure.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly DatabaseContext _db;

        public ApplicationRepository(DatabaseContext db)
            => _db = db;

        public Task<Domain.Models.Application> CreateApplication(Domain.Models.Application application)
        {
            _db.Applications.Add(application);
            _db.SaveChanges();
            return Task.FromResult(application);
        }

        public Task<Domain.Models.Application> DeleteApplication(int applicationId)
        {
            var application = GetApplication(applicationId).Result;
            _db.Applications.Remove(application);
            _db.SaveChanges();
            return Task.FromResult(application);
        }

        public Task<Domain.Models.Application> GetApplication(int applicationId)
        {
            var application = _db.Applications.Find(applicationId);
            return Task.FromResult(application);
        }

        public Task<List<Domain.Models.Application>> GetApplicationsForEmployee(Employee employee)
            => Task.FromResult(
                _db.Applications.Where(a => a.Employee == employee).ToList()
            );

        public Task<Domain.Models.Application> UpdateApplication(
            int applicationId,
            Domain.Models.Application application)
        {
            application.Id = applicationId;
            _db.Applications.Update(application);
            _db.SaveChanges();
            return Task.FromResult(application);
        }

        public Task<List<Domain.Models.Application>> GetApplicationsForJob(Job job)
            => Task.FromResult(
                _db.Applications.Where(a => a.Job == job).ToList()
            );
        
    }
}
