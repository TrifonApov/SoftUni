window.addEventListener("load", solve);

function solve() {
  const selectors = {
    titleInput: document.querySelector("#title"),
    descInput: document.querySelector("#description"),
    featureInput: document.querySelector("#label"),
    estimationPtsInput: document.querySelector("#points"),
    assigneeInput: document.querySelector("#assignee"),
    createBtn: document.querySelector("#create-task-btn"),
    deleteTaskBtn: document.querySelector("#delete-task-btn"),
    totalPoints: document.querySelector("#total-sprint-points"),
    tasks: document.querySelector("#tasks-section"),
  };

  const symbols = {
    Feature: "&#8865;",
    "Low Priority Bug": "&#9737;",
    "High Priority Bug": "&#9888;",
  };
  let id = 0;

  selectors.createBtn.addEventListener("click", createTask);
  selectors.deleteTaskBtn.addEventListener("click", confirmDelete);

  function createTask(event) {
    event.preventDefault();
    id++;

    const article = createElement(
      "article",
      null,
      ["task-card"],
      `task-${id}`,
      selectors.tasks
    );

    const taskLabel = createElement(
      "div",
      null,
      ["task-card-label", selectors.featureInput.value],
      null,
      article,
      `${selectors.featureInput.value} ${symbols[selectors.featureInput.value]}`
    );
  }

  function confirmDelete(event) {
    event.preventDefault();
  }

  function createElement(type, textContent, classes, id, parent, useInnerHTML) {
    const element = document.createElement(type);

    if (useInnerHTML) {
      element.innerHTML = useInnerHTML;
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
