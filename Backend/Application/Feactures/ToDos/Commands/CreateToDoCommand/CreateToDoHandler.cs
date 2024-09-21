using Application.Commons.Models;
using Entities;
using FluentValidation;
using MediatR;
using Services.ToDoServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feactures.ToDos.Commands.CreateToDoCommand
{
    public class CreateToDoHandler : IRequestHandler<CreateToDoCommand, BaseResponse<ToDo>>
    {
        private readonly IToDoService toDoService;
        private readonly IValidator<CreateToDoCommand> validator;
        
        public CreateToDoHandler(IToDoService _toDoService, IValidator<CreateToDoCommand> _validator)
        {
            toDoService = _toDoService;
            validator = _validator;
        }

        public async Task<BaseResponse<ToDo>> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid) {

                ToDo newTodo = new ToDo
                {
                    TodoTitle = request.TodoTitle,
                    TodoContent = request.TodoContent
                };


                ToDo added = await toDoService.Add(newTodo);

                return new BaseResponse<ToDo>(added);
            }

            return new BaseResponse<ToDo>(validationResult.ToString());




        }
    }
}
