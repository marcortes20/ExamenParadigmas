import { useState, useEffect } from 'react';
import { HubConnectionBuilder } from '@microsoft/signalr';

export function useSignalRConnection(addToDo) {
  const [connection, setConection] = useState(null);
  useEffect(() => {
    const connection = new HubConnectionBuilder()
      .withUrl('http://localhost:5267/ToDoHub')
      .withAutomaticReconnect()
      .build();

    setConection(connection);
  }, []);

  useEffect(() => {
    if (connection) {
      connection
        .start()
        .then(() => console.log('Connected to SignalR hub'))
        .catch((err) => console.error('Error connecting to hub:', err));

      connection.on('SendToDo', (todo) => {
        console.log(todo);
        addToDo(todo);
      });
    }
  }, [connection]);
}
