const BASE_URL = `http://localhost:3030/jsonstore/tasks/`;
let courseToEdit = {};
const selectors = {
  loadCoursesBtn: document.querySelector("#load-course"),
  confirmEditCourseBtn: document.querySelector("#edit-course"),
  addCourseBtn: document.querySelector("#add-course"),
  courseTitleInput: document.querySelector("#course-name"),
  courseTypeInput: document.querySelector("#course-type"),
  courseDescriptionInput: document.querySelector("#description"),
  courseTeacherInput: document.querySelector("#teacher-name"),
  coursesInProgress: document.querySelector("#list"),
};

selectors.loadCoursesBtn.addEventListener("click", loadCourses);
selectors.confirmEditCourseBtn.addEventListener("click", confirmEditCourse);
selectors.addCourseBtn.addEventListener("click", addCourse);

async function loadCourses(event) {
  const courses = await (await fetch(BASE_URL)).json();
  selectors.coursesInProgress.innerHTML = "";
  Object.values(courses).forEach((course) => {
    const container = createElement(
      "div",
      null,
      ["container"],
      course["_id"],
      selectors.coursesInProgress
    );

    const courseTitle = createElement(
      "h2",
      course["title"],
      null,
      null,
      container
    );

    const courseTeacher = createElement(
      "h3",
      course["teacher"],
      null,
      null,
      container
    );

    const courseType = createElement(
      "h3",
      course["type"],
      null,
      null,
      container
    );

    const courseDescription = createElement(
      "h4",
      course["description"],
      null,
      null,
      container
    );

    const editCourseBtn = createElement(
      "button",
      "Edit Course",
      ["edit-btn"],
      null,
      container
    );

    const finishCourseBtn = createElement(
      "button",
      "Finish Course",
      ["finish-btn"],
      null,
      container
    );

    editCourseBtn.addEventListener("click", editCourse);
    finishCourseBtn.addEventListener("click", finishCourse);
  });
}

async function addCourse(event) {
  event.preventDefault();
  const newCourse = {
    title: selectors.courseTitleInput.value,
    type: selectors.courseTypeInput.value,
    description: selectors.courseDescriptionInput.value,
    teacher: selectors.courseTeacherInput.value,
  };

  if (Object.values(newCourse).some((c) => !c)) {
    console.log("Missing data");
    return;
  }

  if (
    newCourse.type !== "Long" &&
    newCourse.type !== "Medium" &&
    newCourse.type !== "Short"
  ) {
    console.log("Type should be either “Long”, “Medium”, or “Short”");
    return;
  }

  const headers = {
    method: "POST",
    body: JSON.stringify(newCourse),
  };

  fetch(BASE_URL, headers).then(() => {
    selectors.courseTitleInput.value = "";
    selectors.courseTypeInput.value = "";
    selectors.courseDescriptionInput.value = "";
    selectors.courseTeacherInput.value = "";

    loadCourses();
  });
}

async function confirmEditCourse(event) {
  event.preventDefault();

  const editedCourse = {
    title: selectors.courseTitleInput.value,
    type: selectors.courseTypeInput.value,
    description: selectors.courseDescriptionInput.value,
    teacher: selectors.courseTeacherInput.value,
  };

  if (Object.values(editedCourse).some((c) => !c)) {
    console.log("Missing data");
    return;
  }

  if (
    editedCourse.type !== "Long" &&
    editedCourse.type !== "Medium" &&
    editedCourse.type !== "Short"
  ) {
    console.log("Type should be either “Long”, “Medium”, or “Short”");
    return;
  }

  const headers = {
    method: "PUT",
    body: JSON.stringify(editedCourse),
  };

  fetch(`${BASE_URL}${courseToEdit.id}`, headers).then(() => {
    selectors.addCourseBtn.disabled = false;
    selectors.confirmEditCourseBtn.disabled = true;

    selectors.courseTitleInput.value = "";
    selectors.courseTypeInput.value = "";
    selectors.courseDescriptionInput.value = "";
    selectors.courseTeacherInput.value = "";

    loadCourses();
  });
}

function editCourse(event) {
  selectors.addCourseBtn.disabled = true;
  selectors.confirmEditCourseBtn.disabled = false;

  courseToEdit = event.target.parentElement;

  selectors.courseTitleInput.value = courseToEdit.children[0].textContent;
  selectors.courseTeacherInput.value = courseToEdit.children[1].textContent;
  selectors.courseTypeInput.value = courseToEdit.children[2].textContent;
  selectors.courseDescriptionInput.value = courseToEdit.children[3].textContent;
}

function finishCourse(event) {
  event.preventDefault();
  const parent = event.target.parentElement;

  fetch(`${BASE_URL}${parent.id}`, {
    method: "DELETE",
  })
    .then((res) => res.json())
    .then(loadCourses());
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
