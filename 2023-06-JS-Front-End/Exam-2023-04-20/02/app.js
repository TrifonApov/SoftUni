window.addEventListener("load", solve);

function solve() {
  const selectors = {
    titleInput: document.querySelector("#task-title"),
    categoryInput: document.querySelector("#task-category"),
    contentInput: document.querySelector("#task-content"),
    publishBtn: document.querySelector("#publish-btn"),
    reviewList: document.querySelector("#review-list"),
    tasksList: document.querySelector("#published-list"),
  };

  selectors.publishBtn.addEventListener("click", sendTaskForReview);

  function sendTaskForReview(event) {
    event.preventDefault();
    if (
      !selectors.titleInput.value ||
      !selectors.categoryInput.value ||
      !selectors.contentInput.value
    ) {
      return;
    }

    const reviewPost = createElement(
      "li",
      null,
      ["rpost"],
      null,
      selectors.reviewList
    );

    const article = createElement("article", null, null, null, reviewPost);
    const title = createElement(
      "h4",
      selectors.titleInput.value,
      null,
      null,
      article
    );
    const category = createElement(
      "p",
      `Category: ${selectors.categoryInput.value}`,
      null,
      null,
      article
    );
    const content = createElement(
      "p",
      `Content: ${selectors.contentInput.value}`,
      null,
      null,
      article
    );

    const editBtn = createElement(
      "button",
      "Edit",
      ["action-btn", "edit"],
      null,
      reviewPost
    );
    const postBtn = createElement(
      "button",
      "Post",
      ["action-btn", "post"],
      null,
      reviewPost
    );

    editBtn.addEventListener("click", editTask);
    postBtn.addEventListener("click", postTask);

    selectors.titleInput.value = "";
    selectors.categoryInput.value = "";
    selectors.contentInput.value = "";
  }

  function editTask(event) {
    event.preventDefault();
    const parent = event.target.parentElement;
    const [title, category, content] = [
      parent.children[0].children[0].textContent.split(": "),
      parent.children[0].children[1].textContent.split(": ")[1],
      parent.children[0].children[2].textContent.split(": ")[1],
    ];

    selectors.titleInput.value = title;
    selectors.categoryInput.value = category;
    selectors.contentInput.value = content;
    parent.remove();
  }

  function postTask(event) {
    event.preventDefault();
    const parent = event.target.parentElement;
    const actionBtns = Array.from(document.querySelectorAll(".action-btn"));
    actionBtns.forEach((element) => element.remove());
    parent.remove();

    selectors.tasksList.appendChild(parent);
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
