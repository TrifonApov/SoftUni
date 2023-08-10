const BASE_URL = `http://localhost:3030/jsonstore/tasks/`;
let id = "";
const selectors = {
  loadVacations: document.querySelector("#load-vacations"),
  list: document.querySelector("#list"),
  addVacationBtn: document.querySelector("#add-vacation"),
  confirmEditBtn: document.querySelector("#edit-vacation"),

  inputName: document.querySelector("#name"),
  inputNumberOfDays: document.querySelector("#num-days"),
  inputFromDate: document.querySelector("#from-date"),
};

selectors.loadVacations.addEventListener("click", loadVacations);
selectors.addVacationBtn.addEventListener("click", addVacation);
selectors.confirmEditBtn.addEventListener("click", confirmEdit);

async function loadVacations(event) {
  const vacations = await (await fetch(BASE_URL)).json();
  selectors.list.innerHTML = "";

  Object.values(vacations).forEach((vacation) => {
    const container = createElement(
      "div",
      null,
      ["container"],
      null,
      selectors.list
    );
    const name = createElement("h2", vacation.name, null, null, container);
    const fromDate = createElement("h3", vacation.date, null, null, container);
    const days = createElement("h2", vacation.days, null, null, container);
    const changeBtn = createElement(
      "button",
      "Change",
      ["change-btn"],
      null,
      container
    );
    changeBtn.addEventListener("click", editVacations);

    const doneBtn = createElement(
      "button",
      "Done",
      ["done-btn"],
      null,
      container
    );
    doneBtn.addEventListener("click", doneVacations);
  });
  console.log(JSON.stringify(vacations, null, 2));
}

function addVacation(event) {
  event.preventDefault();
  const newVacation = {
    name: selectors.inputName.value,
    days: selectors.inputNumberOfDays.value,
    date: selectors.inputFromDate.value,
  };

  if (Object.values(newVacation).some((value) => !value)) {
    console.log(`No valid data`);
    return;
  }

  const httpHeaders = {
    method: "POST",
    body: JSON.stringify(newVacation),
  };

  fetch(BASE_URL, httpHeaders)
    .then((e) => {
      loadVacations();
      selectors.inputName.value = "";
      selectors.inputNumberOfDays.value = "";
      selectors.inputFromDate.value = "";
    })
    .catch(console.error());
}

async function editVacations(event) {
  const [name, fromDate, days] = Array.from(
    event.currentTarget.parentElement.children
  ).splice(0, 3);
  selectors.inputName.value = name.textContent;
  selectors.inputFromDate.value = fromDate.textContent;
  selectors.inputNumberOfDays.value = days.textContent;

  const vacations = await (await fetch(BASE_URL)).json();
  id = Object.values(vacations).find((v) => v.name === name.textContent)[`_id`];

  selectors.addVacationBtn.disabled = true;
  selectors.confirmEditBtn.disabled = false;
}

async function confirmEdit(event) {
  event.preventDefault();

  const editedVacation = {
    name: selectors.inputName.value,
    days: selectors.inputNumberOfDays.value,
    date: selectors.inputFromDate.value,
    _id: id,
  };

  if (Object.values(editedVacation).some((value) => !value)) {
    console.log(`No valid data`);
    return;
  }

  const headers = {
    method: "PUT",
    body: JSON.stringify(editedVacation),
  };

  fetch(`${BASE_URL}${id}`, headers)
    .then(() => {
      selectors.inputName.value = "";
      selectors.inputNumberOfDays.value = "";
      selectors.inputFromDate.value = "";
      selectors.confirmEditBtn.disabled = true;
      selectors.addVacationBtn.disabled = false;
      loadVacations();
    })
    .catch(console.error());
}

async function doneVacations(event) {
  event.preventDefault();
  const vacations = await (await fetch(BASE_URL)).json();
  const name = event.target.parentElement.children[0].textContent;
  console.log(vacations);
  const vacationToDone = Object.values(vacations).find((v) => v.name === name)[
    "_id"
  ];

  fetch(`${BASE_URL}${vacationToDone}`, {
    method: "DELETE",
  })
    .then((res) => res.json())
    .then((res) => {
      loadVacations();
    });
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
