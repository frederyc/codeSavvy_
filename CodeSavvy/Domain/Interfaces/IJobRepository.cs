﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;

namespace CodeSavvy.Domain.Interfaces
{
    public interface IJobRepository
    {
        Task<Job> CreateJob(Job job);
        Task<Job> DeleteJob(int jobId);
        Task<Job> GetJob(int jobId);
        Task<Job> UpdateJob(int jobId, Job job);
    }
}
