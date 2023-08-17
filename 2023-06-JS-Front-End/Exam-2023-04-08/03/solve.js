// TODO:

const BASE_URL = "http://localhost:3030/jsonstore/tasks/";
const selectors = {
  loadBoardBtn: document.querySelector("#load-board-btn"),
  enterTaskTitle: document.querySelector("#title"),
  enterTaskDescription: document.querySelector("#description"),
  addTaskBtn: document.querySelector("#create-task-btn"),
};
const lists = {
  ToDo: document.querySelector("#todo-section > ul"),
  "In Progress": document.querySelector("#in-progress-section > ul"),
  "Code Review": document.querySelector("#code-review-section > ul"),
  Done: document.querySelector("#done-section > ul"),
};
const moveBtnContent = {
  ToDo: "Move to In Progress",
  "In Progress": "Move to Code Review",
  "Code Review": "Move to Done",
  Done: "Close",
};

selectors.loadBoardBtn.addEventListener("click", loadBoard);
selectors.addTaskBtn.addEventListener("click", addTask);

function loadBoard(event) {
  event.preventDefault();
  fetch(BASE_URL)
    .then((res) => res.json())
    .then((tasks) => {
      const a = selectors.ToDo;
      a.innerHTML = "";
      selectors["In Progress"].textContent = "";
      selectors["Code Review"].textContent = "";
      selectors["Done"].textContent = "";
      Object.values(tasks).forEach((task) => {
        const taskItem = createElement(
          "li",
          null,
          ["task"],
          task["_id"],
          lists[task["status"]]
        );
        const title = createElement("h3", task["title"], null, null, taskItem);
        const description = createElement(
          "p",
          task["description"],
          null,
          null,
          taskItem
        );
        const moveBtn = createElement(
          "button",
          moveBtnContent[task["status"]],
          null,
          null,
          taskItem
        );
        moveBtn.addEventListener("click", moveTask);
      });
    });
}

function addTask(event) {}

function moveTask(event) {
  console.log("moveBnt");
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
