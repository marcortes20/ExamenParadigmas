import './App.css';
import { useCreateToDo } from './Hooks/ToDos/useCreateToDo';
import { useSignalRConnection } from './Hooks/SignalR/useSignalRConnection';
import { useGetAllToDos } from './Hooks/ToDos/useGetAllToDos';
import { useDeleteToDo } from './Hooks/ToDos/useDeleteToDo';

function App() {
  const { getToDos, toDos, addToDo } = useGetAllToDos();

  useSignalRConnection(addToDo);

  const {
    onSubmit,
    erros,
    setToDoTitle,
    setToDoContent,
    toDoContent,
    toDoTitle,
  } = useCreateToDo();

  const { deleteToDo } = useDeleteToDo(getToDos);

  return (
    <>
      <main>
        <h1>TO DO APP</h1>

        <div>
          {erros.length > 0 && (
            <ul className="errorList">
              {erros.map((error, index) => (
                <li key={index}>{error}</li>
              ))}
            </ul>
          )}
        </div>

        <form onSubmit={onSubmit} id="toDoForm">
          <div className="todoFields">
            <label htmlFor="toDoTitle">New ToDo Title</label>
            <input
              onChange={(e) => setToDoTitle(e.target.value)}
              type="text"
              name="toDoTitle"
              value={toDoTitle}
            ></input>
          </div>

          <div className="todoFields">
            <label htmlFor="toDoContent">New ToDo Content</label>
            <textarea
              onChange={(e) => setToDoContent(e.target.value)}
              name="toDoContent"
              rows="5"
              cols="25"
              value={toDoContent}
            ></textarea>
          </div>

          <input type="submit" value="Send"></input>
        </form>

        {toDos.length > 0 && (
          <div>
            <h2>TO DO LIST</h2>

            <ul className="todoList">
              {toDos.map((todo, index) => (
                <li className="item" key={index}>
                  {todo.todoTitle}
                  <button
                    className="deleteBtn"
                    onClick={() => deleteToDo(todo.id)}
                  >
                    Delete
                  </button>
                </li>
              ))}
            </ul>
          </div>
        )}
      </main>
    </>
  );
}

export default App;
