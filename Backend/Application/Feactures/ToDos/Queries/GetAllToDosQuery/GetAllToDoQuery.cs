using Application.Commons.Models;
using Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feactures.ToDos.Queries.GetAllToDosQuery
{
    public class GetAllToDoQuery : IRequest<BaseResponse<IEnumerable<ToDo>>>
    {
    }
}
