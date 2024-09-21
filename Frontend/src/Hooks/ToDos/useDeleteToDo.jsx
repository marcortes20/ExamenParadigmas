export function useDeleteToDo(getToDos) {
  async function deleteToDo(id) {
    try {
      const response = await fetch(`http://localhost:5267/api/ToDo?id=${id}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
        },
      });

      if (response.ok) {
        getToDos();

        return;
      }
    } catch (error) {
      console.log(error);
    }
  }

  return { deleteToDo };
}
