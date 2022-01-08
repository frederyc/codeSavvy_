using AutoMapper;
using CodeSavvy.Application.Credentials.Commands;
using CodeSavvy.Application.Credentials.Commands.UpdateCredentialsCommand;
using CodeSavvy.Domain.Models;
using CodeSavvy.WebUI.ViewModels.CredentialsViewModels;

namespace CodeSavvy.WebUI.Profiles
{
    public class CredentialsProfile : Profile
    {
        public CredentialsProfile()
        {
            CreateMap<Credentials, GetCredentialsViewModel>();
            CreateMap<CreateCredentialsViewModel, CreateCredentialsCommand>();
            CreateMap<CreateCredentialsViewModel, UpdateCredentialsCommand>();
            //CreateMap<GetCredentialsViewModel, UpdateCredentialsCommand>();
        }
    }
}
