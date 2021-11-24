using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Favorites.Queries.GetFavoriteByIdQuery
{
    public class GetFavoriteByIdQuery : IRequest<Favorite>
    {
        public int Id { get; set; }
    }
}
