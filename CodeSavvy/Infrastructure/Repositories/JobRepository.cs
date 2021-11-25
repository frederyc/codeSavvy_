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
    public class JobRepository : IJobRepository
    {
        private readonly DatabaseContext _db;

        public JobRepository(DatabaseContext db)
        {
            _db = db;
        }

        public Task<Job> CreateJob(Job job)
        {
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
            var job = _db.Jobs.Find(jobId);
            return Task.FromResult(job);
        }

        public Task<Job> UpdateJob(int jobId, Job job)
        {
            job.Id = jobId;
            _db.Jobs.Update(job);
            _db.SaveChanges();
            return Task.FromResult(job);
        }
    }
}
