import { useState } from 'react';

export function useCreateToDo() {
  const [erros, setErros] = useState([]);
  const [toDoTitle, setToDoTitle] = useState('');
  const [toDoContent, setToDoContent] = useState('');

  function refreshFields() {
    setToDoTitle('');
    setToDoContent('');
  }

  function refreshErrors() {
    setErros([]);
  }

  async function onSubmit(event) {
    event.preventDefault();
    try {
      const response = await fetch(`http://localhost:5267/api/ToDo`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          todoTitle: toDoTitle,
          todoContent: toDoContent,
        }),
      });
      const json = await response.json();
      if (!response.ok) {
        const validationErros = json.message.split('.');
        setErros([...validationErros]);
        return;
      }
      refreshFields();
      refreshErrors();
    } catch (error) {
      console.log(error);
    }
  }

  return {
    onSubmit,
    erros,
    setToDoTitle,
    setToDoContent,
    toDoContent,
    toDoTitle,
  };
}
