using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Favorites.Commands.DeleteFavoriteCommand
{
    public class DeleteFavoriteCommandHandler : 
        IRequestHandler<DeleteFavoriteCommand, Favorite>
    {
        private readonly IFavoriteRepository _repo;

        public DeleteFavoriteCommandHandler(IFavoriteRepository repo)
            => _repo = repo;

        public async Task<Favorite> Handle(
            DeleteFavoriteCommand request,
            CancellationToken cancellationToken)
            => await _repo.DeleteFavoriteRecord(request.Id);
    }
}
