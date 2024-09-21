using Application.Commons.Models;
using Entities;
using MediatR;
using MediatR.Pipeline;
using Services.ToDoServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feactures.ToDos.Queries.GetAllToDosQuery
{
    public class GetAllToDoHandler : IRequestHandler<GetAllToDoQuery, BaseResponse<IEnumerable<ToDo>>>
    {

        private readonly IToDoService toDoService;
        public GetAllToDoHandler(IToDoService _toDoService)
        {
            toDoService = _toDoService;
        }

        public async Task<BaseResponse<IEnumerable<ToDo>>> Handle(GetAllToDoQuery request, CancellationToken cancellationToken)
        {

            var allToDos = await toDoService.GetAll(); 

            var response = new BaseResponse<IEnumerable<ToDo>>(allToDos); 

            return response; 
        }

      
    }
}
