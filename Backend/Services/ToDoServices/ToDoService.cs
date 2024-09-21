using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.PatternRepository;


namespace Services.ToDoServices
{
    public class ToDoService : Repository<ToDo>, IToDoService
    {
   
     public async Task<ToDo> addTodo(ToDo toDo)
        {
           
            return await Add(toDo);
        }

      /*  public async IEnumerable<ToDo> getAllToDos()
        {
          IEnumerable <ToDo> list = await GetAll();

            return list;
        }
        */
        public async void deleteToDo(int id)
        {
            ToDo todoToRemove = await GetById(id);

            if (todoToRemove != null) {
                Delete(todoToRemove);
            }
           
           
        }



    }
}
