const BASE_URL = "http://localhost:3030/jsonstore/tasks/";
const titleInput = document.querySelector("#title");
const addButton = document.querySelector("#add-button");
const loadButton = document.querySelector("#load-button");
const taskList = document.querySelector("#todo-list");

loadButton.addEventListener("click", loadAllTasks);
addButton.addEventListener("click", addTask);

function loadAllTasks(event) {
  event.preventDefault();
  taskList.innerHTML = "";
  fetch(BASE_URL)
    .then((res) => res.json())
    .then((tasks) => {
      console.log(tasks);
      Object.values(tasks).forEach((task) => {
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
        removeButton.addEventListener("click", removeTask);
        editButton.addEventListener("click", editTask);
      });
    });
}

function addTask(event) {
  event.preventDefault();
  const newTask = { name: titleInput.value };
  const headers = {
    method: "POST",
    body: JSON.stringify(newTask),
  };
  fetch(BASE_URL, headers).then(loadAllTasks()).catch(console.error());
}

function removeTask(event) {
  event.preventDefault();
  console.log("remove");
}

function editTask(event) {
  event.preventDefault();
  console.log("edit");
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
