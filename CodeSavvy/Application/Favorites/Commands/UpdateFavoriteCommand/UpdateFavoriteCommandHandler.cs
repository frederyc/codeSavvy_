using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Favorites.Commands.UpdateFavoriteCommand
{
    public class UpdateFavoriteCommandHandler : 
        IRequestHandler<UpdateFavoriteCommand, Favorite>
    {
        private readonly IFavoriteRepository _repo;

        public UpdateFavoriteCommandHandler(IFavoriteRepository repo)
            => _repo = repo;

        public async Task<Favorite> Handle(
            UpdateFavoriteCommand request,
            CancellationToken cancellationToken)
        {
            var favorite = new Favorite
            {
                Employee = new Employee
                {
                    Id = request.EmployeeId
                },
                Job = new Job
                {
                    Id = request.JobId
                }
            };
            return await _repo.UpdateFavoriteRecord(request.Id, favorite);
        }
    }
}
