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
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly DatabaseContext _db;

        public ApplicationRepository(DatabaseContext db)
        {
            _db = db;
        } 

        public async Task<Domain.Models.Application> CreateApplication(Domain.Models.Application application)
        {
            _ = application ?? throw new ApplicationNullArgumentException();
            await _db.Applications.AddAsync(application);
            await _db.SaveChangesAsync();
            return application;
        }

        public async Task<Domain.Models.Application> DeleteApplication(int applicationId)
        {
            var application = await GetApplication(applicationId);
            _db.Applications.Remove(application);
            await _db.SaveChangesAsync();
            return application;
        }

        public async Task<Domain.Models.Application> GetApplication(int applicationId)
        {
            var application = await _db.Applications
                                  .Include(x => x.Employee)
                                  .Include(x => x.Job)
                                  .Include(x => x.Job.Employer)
                                  .SingleAsync(x => x.Id == applicationId) ?? 
                              throw new ApplicationNotFoundException($"Application with Id: {applicationId} could not be found");
            return application;
        }

        public async Task<List<Domain.Models.Application>> GetApplicationsForEmployee(int employeeId)
        {
            //_ = employee ?? throw new EmployeeNullArgumentException();
            return await _db.Applications.Where(a => a.Employee.Id == employeeId)
                .Include(a => a.Employee)
                .Include(x => x.Job)
                .Include(x => x.Job.Employer)
                .ToListAsync();
        }

        public async Task<Domain.Models.Application> UpdateApplication(int applicationId, Domain.Models.Application application)
        {
            _ = application ?? throw new ApplicationNullArgumentException();
            var applicationEntity = await GetApplication(applicationId);
            applicationEntity.Employee = application.Employee;
            applicationEntity.Job = application.Job;
            applicationEntity.Resume = application.Resume;
            await _db.SaveChangesAsync();
            return application;
        }

        public async Task<List<Domain.Models.Application>> GetApplicationsForJob(int jobId)
        {
            //_ = job ?? throw new JobNullArgumentException();
            return await _db.Applications.Where(a => a.Job.Id == jobId)
                .Include(a => a.Employee)
                .Include(a => a.Job)
                .ToListAsync();
        }

        /*_ = credentials ?? throw new CredentialsNullArgumentException();            // Check if credentials argument is null
            var credentialsEntity = await GetCredentials(credentialsId);                // Get credentials entity from db
            credentialsEntity.Email = credentials.Email;                                // Set email and password of entity with user input
            credentialsEntity.Password = credentials.Password;          
            await _db.SaveChangesAsync();                                   
            return credentials;*/

    }
}
