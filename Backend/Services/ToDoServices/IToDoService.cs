using Services.patternRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;


namespace Services.ToDoServices
{
    public interface IToDoService : IRepository<ToDo>
    {
        public Task<ToDo> addTodo(ToDo toDo);
       // public Task<IEnumerable<ToDo>> getAllToDos();

        public void deleteToDo(int id);
    }
}
