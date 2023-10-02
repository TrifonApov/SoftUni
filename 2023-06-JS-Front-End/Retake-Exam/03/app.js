const BASE_URL = "http://localhost:3030/jsonstore/tasks/";
const selectors = {
  loadBtn: document.querySelector("#load-history"),
  addBtn: document.querySelector("#add-weather"),
  confirmEditBtn: document.querySelector("#edit-weather"),
  list: document.querySelector("#list"),
};
const input = {
  location: document.querySelector("#location"),
  temperature: document.querySelector("#temperature"),
  date: document.querySelector("#date"),
};

let reportToChangeId = "";

selectors.loadBtn.addEventListener("click", loadRecords);

function loadRecords(event) {
  // event.preventDefault();
  selectors.list.innerHTML = "";
  fetch(BASE_URL)
    .then((res) => res.json())
    .then((records) => {
      Object.values(records).forEach((record) => {
        const container = createElement(
          "div",
          null,
          ["container"],
          record["_id"],
          selectors.list
        );
        const location = createElement(
          "h2",
          record["location"],
          null,
          null,
          container
        );
        const date = createElement("h3", record["date"], null, null, container);
        const temperature = createElement(
          "h3",
          record["temperature"],
          null,
          null,
          container
        );

        const btnContainer = createElement(
          "div",
          null,
          ["buttons-container"],
          null,
          container
        );

        const changeBtn = createElement(
          "button",
          "Change",
          ["change-btn"],
          null,
          btnContainer
        );
        changeBtn.addEventListener("click", change);

        const deleteBtn = createElement(
          "button",
          "Delete",
          ["delete-btn"],
          null,
          btnContainer
        );
        deleteBtn.addEventListener("click", deleteReport);
      });
    });
}

selectors.addBtn.addEventListener("click", add);
function add(event) {
  event.preventDefault();
  if (!input.location.value || !input.temperature.value || !input.date.value) {
    console.log("Missing data");
    return;
  }

  const newReport = {
    location: input.location.value,
    temperature: input.temperature.value,
    date: input.date.value,
  };
  const headers = {
    method: "POST",
    body: JSON.stringify(newReport),
  };
  fetch(BASE_URL, headers)
    .then(() => {
      input.location.value = "";
      input.temperature.value = "";
      input.date.value = "";
      loadRecords();
    })
    .catch((err) => console.error);
}

function change(event) {
  event.preventDefault();
  reportToChangeId = event.target.parentElement.parentElement.id;

  const reportContainer = event.target.parentElement.parentElement;
  const location = reportContainer.children[0].textContent;
  const date = reportContainer.children[1].textContent;
  const temperature = reportContainer.children[2].textContent;

  input.location.value = location;
  input.date.value = date;
  input.temperature.value = temperature;

  selectors.addBtn.disabled = true;
  selectors.confirmEditBtn.disabled = false;

  selectors.confirmEditBtn.addEventListener("click", confitmEdit);
  reportContainer.remove();
}

function deleteReport(event) {
  event.preventDefault();

  const reportId = event.target.parentElement.parentElement.id;

  fetch(`${BASE_URL}${reportId}`, { method: "DELETE" })
    .then(() => loadRecords())
    .catch(console.error);
}

function confitmEdit(event) {
  event.preventDefault();

  const reportToEdit = {};
  reportToEdit["location"] = input.location.value;
  reportToEdit["temperature"] = input.temperature.value;
  reportToEdit["date"] = input.date.value;

  const headers = { method: "PUT", body: JSON.stringify(reportToEdit) };
  fetch(`${BASE_URL}${reportToChangeId}`, headers)
    .then(() => {
      selectors.addBtn.disabled = false;
      selectors.confirmEditBtn = true;
      input.location.value = "";
      input.temperature.value = "";
      input.date.value = "";
      loadRecords();
    })
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
