using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Favorites.Queries.GetFavoriteForEmployee
{
    public class GetFavoriteForEmployeeQuery : IRequest<List<Favorite>>
    {
        public Employee Employee { get; set; }
    }
}
