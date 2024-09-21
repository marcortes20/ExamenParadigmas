using Entities;
using Microsoft.AspNetCore.SignalR;

namespace Backend.SignalR
{
    public class ToDoHub : Hub<IToDoHub>
    {
        public async Task SendToDo(ToDo newToDo)
        {
            await Clients.All.SendToDo(newToDo);
        }

    }
}
