using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Favorites.Commands.CreateFavoriteCommand
{
    public class CreateFavoriteCommand : IRequest<Favorite>
    {
        public Favorite Favorite { get; set; }
    }
}
