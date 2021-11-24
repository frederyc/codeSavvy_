using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Favorites.Queries.GetFavoriteByIdQuery
{
    public class GetFavoriteByIdQueryHandler : 
        IRequestHandler<GetFavoriteByIdQuery, Favorite>
    {
        private readonly IFavoriteRepository _repo;

        public GetFavoriteByIdQueryHandler(IFavoriteRepository repo)
            => _repo = repo;

        public async Task<Favorite> Handle(
            GetFavoriteByIdQuery request,
            CancellationToken cancellationToken)
            => await _repo.GetFavoriteRecord(request.Id);
    }
}
