using AutoMapper;
using CodeSavvy.Application.Applications.Commands.CreateApplicationCommand;
using CodeSavvy.Application.Applications.Commands.UpdateApplicationCommand;
using CodeSavvy.WebUI.ViewModels.ApplicationViewModels;

namespace CodeSavvy.WebUI.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Domain.Models.Application, GetApplicationViewModel>();
            CreateMap<Domain.Models.Application, UpdateApplicationViewModel>();
            CreateMap<CreateApplicationViewModel, CreateApplicationCommand>();
            CreateMap<CreateApplicationViewModel, UpdateApplicationCommand>();
            CreateMap<UpdateApplicationViewModel, UpdateApplicationCommand>();
        }
    }
}
