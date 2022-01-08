using AutoMapper;
using CodeSavvy.Application.Favorites.Commands.CreateFavoriteCommand;
using CodeSavvy.Application.Favorites.Commands.UpdateFavoriteCommand;
using CodeSavvy.Domain.Models;
using CodeSavvy.WebUI.ViewModels.FavoriteViewModels;

namespace CodeSavvy.WebUI.Profiles
{
    public class FavoriteProfile : Profile
    {
        public FavoriteProfile()
        {
            CreateMap<Favorite, GetFavoriteViewModel>();
            CreateMap<CreateFavoriteViewModel, CreateFavoriteCommand>();
            CreateMap<CreateFavoriteViewModel, UpdateFavoriteCommand>();
        }
    }
}
