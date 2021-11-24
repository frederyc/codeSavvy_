using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Favorites.Commands.UpdateFavoriteCommand
{
    public class UpdateFavoriteCommand : IRequest<Favorite>
    {
        public int Id { get; set; }
        public Favorite Favorite { get; set; }
    }
}
