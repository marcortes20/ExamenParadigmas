using Entities;

namespace Backend.SignalR
{
    public interface IToDoHub
    {
        public Task SendToDo(ToDo newToDo);
    }
}
