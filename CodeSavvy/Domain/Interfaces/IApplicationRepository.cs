using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;

namespace CodeSavvy.Domain.Interfaces
{
    public interface IApplicationRepository
    {
        Task<Application> CreateApplication(Application application);
        Task<Application> DeleteApplication(int applicationId);
        Task<Application> GetApplication(int applicationId);
        Task<List<Application>> GetApplicationsForJob(int jobId);
        Task<List<Application>> GetApplicationsForEmployee(int employeeId);
        Task<Application> UpdateApplication(int applicationId, Application application);
    }
}
