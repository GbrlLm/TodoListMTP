document.addEventListener('DOMContentLoaded', function() {

  const form = document.getElementById('form');
  const inputTitulo = document.getElementById('title');
  const inputDescricao = document.getElementById('description');
  const todoLista = document.getElementById('list');

  const urlBase = 'https://localhost:7041/Todo';

  function getTodoTasks() {
    fetch(urlBase)
      .then(response => response.json())
      .then(data => {
        todoLista.innerHTML = '';
        data.forEach(item => criarHtmlTodoTask(item));
      });
  }

  function addTodoTask(){
    form.addEventListener('submit', function(event) {
      event.preventDefault();
      const title = inputTitulo.value.trim();
      const description = inputDescricao.value.trim();
      if (title === '' || description === '') return;
      fetch(urlBase, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ title, description, completed: false })
      })
      .then(response => response.json())
      .then(data => {
        criarHtmlTodoTask(data);
        inputTitulo.value = '';
        inputDescricao.value = '';
      });
    });
  }

  function criarHtmlTodoTask(todoTask) {

    const li = document.createElement('li');
    li.innerHTML = `
      <input type="checkbox" ${todoTask.done ? 'checked' : ''} />
      <span class="${todoTask.done ? 'todoTask-done' : ''}">${todoTask.title} - ${todoTask.description}</span>
      <button class="edit-btn">Edit</button>
      <button class="delete-btn">Delete</button>
    `;
    li.dataset.id = todoTask.id;
    todoLista.appendChild(li);

    // Evento do checkbox
    const checkbox = li.querySelector('input[type="checkbox"]');
    checkbox.addEventListener('change', () => {
      fetch(`${urlBase}/${todoTask.id}`, {
        method: 'PATCH',
        headers: { 'Content-Type': 'application/json' }
      });
      li.querySelector('span').classList.toggle('todoTask-done');
    });

    // Evento de editar TodoTask
    const botaoEditar = li.querySelector('.edit-btn');
    botaoEditar.addEventListener('click', () => {
      const newTitle = prompt('Novo titulo:', todoTask.title);
      const newDescription = prompt('Nova descrição:', todoTask.description);
      if (newTitle !== null && newDescription !== null) {
        fetch(`${urlBase}/${todoTask.id}`, {
          method: 'PUT',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify({ title: newTitle, description: newDescription })
        })
        .then(() => {
          todoTask.title = newTitle;
          todoTask.description = newDescription;
          li.querySelector('span').textContent = `${todoTask.title} - ${todoTask.description}`;
        });
      }
    });

    // Evento de deletar TodoTask
    const botaoDeletar = li.querySelector('.delete-btn');
    botaoDeletar.addEventListener('click', () => {
      fetch(`${urlBase}/${todoTask.id}`, {
        method: 'DELETE'
      })
      .then(() => li.remove());
    });

  }

  addTodoTask();
  
  getTodoTasks();
});