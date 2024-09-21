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

namespace Application.Feactures.ToDos.Commands.DeleteToDoCommand
{
    public class DeleteToDoHandler : IRequestHandler<DeleteToDoCommand, BaseResponse<bool>>
    {

        private readonly IToDoService toDoService;
        private readonly IValidator<DeleteToDoCommand> validator;

        public DeleteToDoHandler(IToDoService _toDoService, IValidator<DeleteToDoCommand> _validator)
        {
            toDoService = _toDoService;
            validator = _validator;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
        {

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid){

                ToDo exist = await toDoService.GetById(request.Id);

                if (exist != null)
                {

                    toDoService.Delete(exist);

                    return new BaseResponse<bool>(true);
                }

                return new BaseResponse<bool>("ToDo was not found");

            }
            

            return new BaseResponse<bool>(validationResult.ToString());
        }
    }
}
