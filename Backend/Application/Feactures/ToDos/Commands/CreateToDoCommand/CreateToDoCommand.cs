using Application.Commons.Models;
using Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feactures.ToDos.Commands.CreateToDoCommand
{
    public class CreateToDoCommand : IRequest<BaseResponse<ToDo>>
    {

        public string TodoTitle { get; set; }
        public string TodoContent { get; set; }
    }
}
