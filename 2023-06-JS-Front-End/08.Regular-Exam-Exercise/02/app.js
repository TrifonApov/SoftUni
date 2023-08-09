window.addEventListener("load", solve);

function solve() {
  const studentEntryInfo = {};
  const selectors = {
    studentName: document.querySelector("#student"),
    university: document.querySelector("#university"),
    score: document.querySelector("#score"),
    nextBtn: document.querySelector("#next-btn"),
    editBtn: document.querySelector(
      "#preview-list > li > button.action-btn.edit"
    ),
    applyBtn: document.querySelector(
      "#preview-list > li > button.action-btn.apply"
    ),
    previewList: document.querySelector("#preview-list"),
    candidatesList: document.querySelector("#candidates-list"),
  };

  selectors.nextBtn.addEventListener("click", next);

  function next(event) {
    studentEntryInfo.name = selectors.studentName.value;
    studentEntryInfo.university = selectors.university.value;
    studentEntryInfo.score = Number(selectors.score.value);

    if (Object.values(studentEntryInfo).some((value) => !value)) {
      console.log(`No valid data`);
      return;
    }

    selectors.studentName.value = "";
    selectors.university.value = "";
    selectors.score.value = "";
    selectors.nextBtn.disabled = true;

    const application = createElement(
      "li",
      null,
      ["application"],
      null,
      selectors.previewList
    );
    const article = createElement("article", null, null, null, application);
    const nameItem = createElement(
      "h4",
      studentEntryInfo.name,
      null,
      null,
      article
    );
    const universityItem = createElement(
      "p",
      `University: ${studentEntryInfo.university}`,
      null,
      null,
      article
    );
    const scoreItem = createElement(
      "p",
      `Score: ${studentEntryInfo.score}`,
      null,
      null,
      article
    );
    const editBtn = createElement(
      "button",
      "edit",
      ["action-btn", "edit"],
      null,
      application
    );
    const applyBtn = createElement(
      "button",
      "apply",
      ["action-btn", "apply"],
      null,
      application
    );

    editBtn.addEventListener("click", edit);
    applyBtn.addEventListener("click", apply);
  }

  function edit(event) {
    selectors.studentName.value = studentEntryInfo.name;
    selectors.university.value = studentEntryInfo.university;
    selectors.score.value = studentEntryInfo.score;
    selectors.nextBtn.disabled = false;
    console.log(selectors.studentName.value);
    console.log(studentEntryInfo);
    const parent = event.target.parentElement;
    parent.remove();
  }

  function apply(event) {
    const parent = event.target.parentElement;
    const actionBtns = Array.from(document.querySelectorAll(".action-btn"));
    actionBtns.forEach((element) => element.remove());
    parent.remove();
    selectors.candidatesList.appendChild(parent);
    selectors.nextBtn.disabled = false;
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
