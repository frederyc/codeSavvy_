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

namespace CodeSavvy.Infrastructure.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly DatabaseContext _db;

        public ApplicationRepository(DatabaseContext db)
            => _db = db;

        public Task<Domain.Models.Application> CreateApplication(Domain.Models.Application application)
        {
            _ = application ?? throw new ApplicationNullArgumentException();
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
            var application = _db.Applications.Find(applicationId) ?? 
                              throw new ApplicationNotFoundException($"Application with Id: {applicationId} could not be found");
            return Task.FromResult(application);
        }

        public Task<List<Domain.Models.Application>> GetApplicationsForEmployee(Employee employee)
        {
            _ = employee ?? throw new EmployeeNullArgumentException();
            return Task.FromResult(
                _db.Applications.Where(a => a.Employee == employee).ToList()
            );
        }

        public Task<Domain.Models.Application> UpdateApplication(int applicationId, Domain.Models.Application application)
        {
            _ = GetApplication(applicationId);
            _ = application ?? throw new ApplicationNullArgumentException();
            application.Id = applicationId;
            _db.Applications.Update(application);
            _db.SaveChanges();
            return Task.FromResult(application);
        }

        public Task<List<Domain.Models.Application>> GetApplicationsForJob(Job job)
        {
            _ = job ?? throw new JobNullArgumentException();
            return Task.FromResult(
                _db.Applications.Where(a => a.Job == job).ToList()
            );
        }

    }
}
