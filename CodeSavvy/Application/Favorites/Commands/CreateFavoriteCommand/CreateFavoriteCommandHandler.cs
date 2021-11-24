using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Favorites.Commands.CreateFavoriteCommand
{
    public class CreateFavoriteCommandHandler : IRequestHandler<CreateFavoriteCommand, Favorite>
    {
        private readonly IFavoriteRepository _repo;

        public CreateFavoriteCommandHandler(IFavoriteRepository repo)
            => _repo = repo;

        public async Task<Favorite> Handle(
            CreateFavoriteCommand request,
            CancellationToken cancellationToken)
            => await _repo.CreateFavoriteRecord(request.Favorite);
    }
}
