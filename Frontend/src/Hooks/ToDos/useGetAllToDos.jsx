import { useState } from 'react';

export function useGetAllToDos() {
  const [toDos, setToDos] = useState([]);

  function addToDo(newToDo) {
    setToDos((prev) => [...prev, newToDo]);
  }

  async function getToDos() {
    try {
      const response = await fetch(`http://localhost:5267/api/ToDo`, {
        headers: {
          'Content-Type': 'application/json',
        },
      });
      const json = await response.json();

      await setToDos(json.data);
      console.log(toDos);
    } catch (error) {
      console.log(error);
    }
  }

  return { getToDos, toDos, addToDo };
}
