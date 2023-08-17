function attachEvents() {
  const BASE_URL = "http://localhost:3030/jsonstore/tasks/";
  const titleInput = document.querySelector("#title");

  const addButton = document.querySelector("#add-button");
  addButton.addEventListener("click", addTask);

  const loadButton = document.querySelector("#load-button");
  loadButton.addEventListener("click", loadAllTasks);

  const taskList = document.querySelector("#todo-list");

  function loadAllTasks(event) {
    event.preventDefault();

    taskList.innerHTML = "";

    fetch(BASE_URL)
      .then((res) => res.json())
      .then((tasks) => {
        Object.values(tasks).forEach((task) => {
          // console.log(task);
          const taskElement = createElement(
            "li",
            null,
            null,
            task["_id"],
            taskList
          );
          const title = createElement(
            "span",
            task["name"],
            null,
            null,
            taskElement
          );
          const removeButton = createElement(
            "button",
            "Remove",
            null,
            null,
            taskElement
          );
          const editButton = createElement(
            "button",
            "Edit",
            null,
            null,
            taskElement
          );
          // removeButton.addEventListener("click", removeTask);
          // editButton.addEventListener("click", editTask);
        });
      })
      .catch((err) => console.log(err));
  }

  function addTask(event) {
    event.preventDefault();
    const newTask = { name: titleInput.value };
    const headers = {
      method: "POST",
      body: JSON.stringify(newTask),
    };
    fetch(BASE_URL, headers)
      .then(() => loadAllTasks(e))
      .catch(console.error());
  }

  function createElement(type, textContent, classes, id, parent, useInnerHTML) {
    const element = document.createElement(type);

    if (useInnerHTML && textContent) {
      element.innerHTML = textContent;
    } else if (textContent) {
      element.textContent = textContent;
    }
    if (classes && classes.length > 0) {
      element.classList.add(...classes);
    }
    if (id) {
      element.setAttribute("id", id);
    }
    if (parent) {
      parent.appendChild(element);
    }
    return element;
  }
}

attachEvents();
