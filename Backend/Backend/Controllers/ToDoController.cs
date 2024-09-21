using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ToDoServices;
using Entities;
using MediatR;
using Application.Feactures.ToDos.Queries.GetAllToDosQuery;
using Application.Feactures.ToDos.Commands.CreateToDoCommand;
using Application.Feactures.ToDos.Commands.DeleteToDoCommand;
using Microsoft.AspNetCore.SignalR;
using Backend.SignalR;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        private readonly IMediator mediator;
        private readonly IHubContext<ToDoHub, IToDoHub> toDoHub;
        public ToDoController(IMediator mediator, IHubContext<ToDoHub, IToDoHub> toDoHub)
        {
            this.mediator = mediator;
            this.toDoHub = toDoHub;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var query = new GetAllToDoQuery();

            var response = await mediator.Send(query);

            if (response.Success) {

                return Ok(response);
            }

            return BadRequest(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateToDoCommand command)
        {

            var response = await mediator.Send(command);

            if (response.Success)
            {
                await toDoHub.Clients.All.SendToDo(response.Data);
                return Ok(response);
            }


            return BadRequest(response);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            var command = new DeleteToDoCommand(id);

            var response = await mediator.Send(command);

            if (response.Success) {

                return Ok(response);
            }
            return BadRequest(response);





        }
    }
        
}

