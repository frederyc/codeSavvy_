using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodeSavvy.Application.Employees.Queries.GetEmployeeByIdQuery;
using CodeSavvy.Application.Favorites.Commands.CreateFavoriteCommand;
using CodeSavvy.Application.Favorites.Commands.DeleteFavoriteCommand;
using CodeSavvy.Application.Favorites.Commands.UpdateFavoriteCommand;
using CodeSavvy.Application.Favorites.Queries.GetFavoriteByIdQuery;
using CodeSavvy.Application.Favorites.Queries.GetFavoriteForEmployee;
using CodeSavvy.Application.Jobs.Queries.GetJobByIdQuery;
using CodeSavvy.Domain.Models;
using CodeSavvy.WebUI.ViewModels.FavoriteViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeSavvy.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FavoriteController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
            

        [HttpPost]
        public async Task<IActionResult> AddFavorite(int jobId, int employeeId)
        {
            var job = await _mediator.Send(new GetJobByIdQuery { Id = jobId });
            var employee = await _mediator.Send(new GetEmployeeByIdQuery { Id = employeeId });
            var favorite = new CreateFavoriteViewModel
            {
                EmployeeId = employeeId,
                JobId = jobId
            };
            var map = _mapper.Map<CreateFavoriteCommand>(favorite);
            map.Job = job;
            map.Employee = employee;
            var result = await _mediator.Send(map);
            return Ok(result);
        }

        [HttpDelete("{id:int}", Name = "DeleteFavoriteById")]
        public async Task<IActionResult> DeleteFavorite(int id)
        {
            var result = await _mediator.Send(new DeleteFavoriteCommand {Id = id});
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFavorite(int id, CreateFavoriteViewModel favorite)
        {
            var map = _mapper.Map<UpdateFavoriteCommand>(favorite);
            map.Id = id;
            var result = await _mediator.Send(map);
            return Ok(result);
        }

        [HttpGet("{id:int}/GetFavoriteById", Name = "GetFavoriteById")]
        public async Task<IActionResult> GetFavoriteById(int id)
        {
            var result = await _mediator.Send(new GetFavoriteByIdQuery {Id = id});
            return Ok(result);
        }

        [HttpGet("{employeeId:int}/GetFavoriteForEmployee", Name = "GetFavoriteForEmployee")]
        public async Task<IActionResult> GetFavoriteForEmployee(int employeeId)
        {
            // todo modify
            var result = await _mediator.Send(new GetFavoriteForEmployeeQuery {EmployeeId = employeeId});
            return Ok(result);
        }

    }
}
