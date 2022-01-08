using AutoMapper;
using CodeSavvy.Application.Employees.Commands.CreateEmployeeCommand;
using CodeSavvy.Application.Employees.Commands.UpdateEmployeeCommand;
using CodeSavvy.Domain.Models;
using CodeSavvy.WebUI.ViewModels.EmployeeViewModels;

namespace CodeSavvy.WebUI.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, GetEmployeeViewModel>();
            CreateMap<Employee, UpdateEmployeeViewModel>();
            CreateMap<CreateEmployeeViewModel, CreateEmployeeCommand>();
            CreateMap<CreateEmployeeViewModel, UpdateEmployeeCommand>();
            CreateMap<GetEmployeeViewModel, UpdateEmployeeCommand>();
            CreateMap<UpdateEmployeeViewModel, UpdateEmployeeCommand>();
        }
    }
}
