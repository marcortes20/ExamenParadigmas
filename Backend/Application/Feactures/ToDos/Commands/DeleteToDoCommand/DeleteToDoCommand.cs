using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commons.Models;
using MediatR;

namespace Application.Feactures.ToDos.Commands.DeleteToDoCommand
{
    public class DeleteToDoCommand : IRequest<BaseResponse<bool>>
    {

        public int Id { get; set; }

        public DeleteToDoCommand(int id)
        {
            Id = id;
        }
    }
}
