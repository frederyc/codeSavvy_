using AutoMapper;
using CodeSavvy.Application.Employers.Commands.CreateEmployerCommand;
using CodeSavvy.Application.Employers.Commands.UpdateEmployerCommand;
using CodeSavvy.Domain.Models;
using CodeSavvy.WebUI.ViewModels.EmployerViewModels;

namespace CodeSavvy.WebUI.Profiles
{
    public class EmployerProfile : Profile
    {
        public EmployerProfile()
        {
            CreateMap<Employer, GetEmployerViewModel>();
            CreateMap<Employer, UpdateEmployerViewModel>();
            CreateMap<CreateEmployerViewModel, CreateEmployerCommand>();
            CreateMap<CreateEmployerViewModel, UpdateEmployerCommand>();
            CreateMap<UpdateEmployerViewModel, UpdateEmployerCommand>();
        }
    }
}
