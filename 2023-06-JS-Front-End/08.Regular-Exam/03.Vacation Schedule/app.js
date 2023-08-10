const loadVacationsBtn = document.querySelector("#load-vacations");
loadVacationsBtn.addEventListener("click", loadVacations);
let vacations;
let arr;
async function loadVacations() {
  vacations = await (
    await fetch("http://localhost:3030/jsonstore/tasks/")
  ).json();

  printVacations(vacations);
}

function printVacations(vacations) {
  const list = document.querySelector("#list");
  list.textContent = "";
  Object.values(vacations).forEach((vacation) => {
    const container = createElement("div", "", ["container"], "", list);
    const name = createElement("h2", vacation.name, [], "", container);
    const date = createElement("h3", vacation.date, [], "", container);
    const days = createElement("h3", vacation.days, [], "", container);
    const editBtn = createElement(
      "button",
      "Change",
      ["change-btn"],
      "",
      container
    );
    const doneBtn = createElement(
      "button",
      "Done",
      ["done-btn"],
      "",
      container
    );
    doneBtn.addEventListener("click", done);
  });
}

const addVacationBtn = document.querySelector("#add-vacation");
addVacationBtn.addEventListener("click", addVacation);

function addVacation() {
  // "07f260f4-466c-4607-9a33-f7273b24f1b4": {
  //     "name": "David Mule",
  //     "days": "5",
  //     "date": "2023-07-09",
  //     "_id": "07f260f4-466c-4607-9a33-f7273b24f1b4"
  // }
  const name = document.querySelector("#name");
  const days = document.querySelector("#num-days");
  const fromDate = document.querySelector("#from-date");

  if (!name || !days || !fromDate) {
    return;
  }

  fetch("http://localhost:3030/jsonstore/tasks/", {
    method: "POST",
    body: JSON.stringify({
      name: name.value,
      days: days.value,
      date: fromDate.value,
    }),
  })
    .then(loadVacations)
    .catch(console.error);
}

function done(e) {
  const button = e.currentTarget;
  const conatiner = button.parentElement;

  const children = Array.from(conatiner.children).splice(0, 3);

  const a = Object.entries(vacations).filter(
    (o) => o[1].name === children[0].textContent
  );

  fetch(`http://localhost:3030/jsonstore/tasks/${a[0][0]}`, {
    method: "DELETE",
  })
    .then(loadVacations)
    .catch(console.error);
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
