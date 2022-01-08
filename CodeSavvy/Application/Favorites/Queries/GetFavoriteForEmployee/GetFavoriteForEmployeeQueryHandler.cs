using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Favorites.Queries.GetFavoriteForEmployee
{
    public class GetFavoriteForEmployeeQueryHandler : 
        IRequestHandler<GetFavoriteForEmployeeQuery, List<Favorite>>
    {
        private readonly IFavoriteRepository _repo;

        public GetFavoriteForEmployeeQueryHandler(IFavoriteRepository repo)
            => _repo = repo;


        public async Task<List<Favorite>> Handle(
            GetFavoriteForEmployeeQuery request,
            CancellationToken cancellationToken)
            => await _repo.GetFavoritesForEmployee(request.EmployeeId);
    }
}
