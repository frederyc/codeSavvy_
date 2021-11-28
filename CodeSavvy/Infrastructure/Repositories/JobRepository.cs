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
    public class JobRepository : IJobRepository
    {
        private readonly DatabaseContext _db;

        public JobRepository(DatabaseContext db)
            => _db = db;

        public Task<Job> CreateJob(Job job)
        {
            _ = job ?? throw new JobNullArgumentException();
            _db.Jobs.Add(job);
            _db.SaveChanges();
            return Task.FromResult(job);
        }

        public Task<Job> DeleteJob(int jobId)
        {
            var job = GetJob(jobId).Result;
            _db.Jobs.Remove(job);
            return Task.FromResult(job);
        }

        public Task<Job> GetJob(int jobId)
        {
            var job = _db.Jobs.Find(jobId) ?? 
                      throw new JobNotFoundException($"Job with Id: {jobId} could not be found");
            return Task.FromResult(job);
        }

        public Task<Job> UpdateJob(int jobId, Job job)
        {
            _ = GetJob(jobId);
            _ = job ?? throw new JobNullArgumentException();
            
            job.Id = jobId;
            _db.Jobs.Update(job);
            _db.SaveChanges();
            return Task.FromResult(job);
        }
    }
}
