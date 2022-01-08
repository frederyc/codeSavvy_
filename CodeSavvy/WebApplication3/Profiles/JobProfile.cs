using AutoMapper;
using CodeSavvy.Application.Jobs.Commands.CreateJobCommand;
using CodeSavvy.Application.Jobs.Commands.UpdateJobCommand;
using CodeSavvy.Domain.Models;
using CodeSavvy.WebUI.ViewModels.JobViewModels;

namespace CodeSavvy.WebUI.Profiles
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<Job, GetJobViewModel>();
            CreateMap<Job, UpdateJobViewModel>();
            CreateMap<CreateJobViewModel, CreateJobCommand>();
            CreateMap<CreateJobViewModel, UpdateJobCommand>();
            CreateMap<UpdateJobViewModel, UpdateJobCommand>();
        }
    }
}
