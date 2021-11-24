using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSavvy.Application.Favorites.Commands.CreateFavoriteCommand;
using CodeSavvy.Application.Favorites.Commands.DeleteFavoriteCommand;
using CodeSavvy.Application.Favorites.Commands.UpdateFavoriteCommand;
using CodeSavvy.Application.Favorites.Queries.GetFavoriteByIdQuery;
using CodeSavvy.Application.Favorites.Queries.GetFavoriteForEmployee;
using CodeSavvy.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeSavvy.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FavoriteController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> AddFavorite(Favorite favorite)
        {
            var result = await _mediator.Send(new CreateFavoriteCommand {Favorite = favorite});
            return Ok(result);
        }

        [HttpDelete("{id:int}", Name = "DeleteFavoriteById")]
        public async Task<IActionResult> DeleteFavorite(int id)
        {
            var result = await _mediator.Send(new DeleteFavoriteCommand {Id = id});
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFavorite(int id, Favorite favorite)
        {
            var result = await _mediator.Send(new UpdateFavoriteCommand
            {
                Id = id,
                Favorite = favorite
            });
            return Ok(result);
        }

        [HttpGet("{id:int}", Name = "GetFavoriteById")]
        public async Task<IActionResult> GetFavoriteById(int id)
        {
            var result = await _mediator.Send(new GetFavoriteByIdQuery {Id = id});
            return Ok(result);
        }

        [HttpGet("{employee}", Name = "GetFavoriteForEmployee")]
        public async Task<IActionResult> GetFavoriteForEmployee(Employee employee)
        {
            var result = await _mediator.Send(new GetFavoriteForEmployeeQuery {Employee = employee});
            return Ok(result);
        }

    }
}
