using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Application.Exceptions.NotFoundException;
using CodeSavvy.Application.Exceptions.NullArgumentException;
using CodeSavvy.Domain.Enums;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using CodeSavvy.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CodeSavvy.Infrastructure.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly DatabaseContext _db;

        public JobRepository(DatabaseContext db)
            => _db = db;

        public async Task<Job> CreateJob(Job job)
        {
            _ = job ?? throw new JobNullArgumentException();
            await _db.Jobs.AddAsync(job);
            await _db.SaveChangesAsync();
            return job;
        }

        public async Task<Job> DeleteJob(int jobId)
        {
            var job = await GetJob(jobId);
            _db.Jobs.Remove(job);
            await _db.SaveChangesAsync();
            return job;
        }

        public async Task<Job> GetJob(int jobId)
        {
            var job = await _db.Jobs
                          .Include(x => x.Employer)
                          .SingleAsync(x => x.Id == jobId) ?? 
                      throw new JobNotFoundException($"Job with Id: {jobId} could not be found");

            return job;
        }

        public async Task<List<Job>> GetJobs(int location, int position, int level, int salary)
        {
            var jobs = await _db.Jobs.Include(x => x.Employer).ToListAsync();

            if (jobs.Count == 0)
                return jobs;

            if (location != -1)
                jobs = jobs.FindAll(x => (int) x.Location == location);
            if (position != -1)
                jobs = jobs.FindAll(x => (int) x.Position == position);
            if (level != -1)
                jobs = jobs.FindAll(x => (int) x.Level == level);
            if (salary != -1)
                jobs = jobs.FindAll(x => x.Salary == salary);

            return jobs;
        }

        public async Task<List<Job>> GetJobs(int employerId)
        {
            var jobs = await _db.Jobs
                                    .Where(x => x.Employer.Id == employerId)
                                    .Include(x => x.Employer)
                                    .ToListAsync();
            return jobs;
        }

        public async Task<Job> UpdateJob(int jobId, Job job)
        {
            _ = job ?? throw new JobNullArgumentException();
            var jobEntity = await GetJob(jobId);
            jobEntity.Employer = job.Employer;
            jobEntity.Description = job.Description;
            jobEntity.Level = job.Level;
            jobEntity.Location = job.Location;
            jobEntity.Position = job.Position;
            jobEntity.MinimumQualifications = job.MinimumQualifications;
            jobEntity.PreferredQualifications = job.PreferredQualifications;
            jobEntity.Salary = job.Salary;
            _db.Jobs.Update(job);
            await _db.SaveChangesAsync();
            return job;
        }
    }
}
