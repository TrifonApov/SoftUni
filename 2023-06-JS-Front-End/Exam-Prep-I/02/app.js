window.addEventListener("load", solve);

function solve() {
  const selectors = {
    firstNameInput: document.querySelector("#first-name"),
    lastNameInput: document.querySelector("#last-name"),
    ageInput: document.querySelector("#age"),
    storyTitleInput: document.querySelector("#story-title"),
    genreInput: document.querySelector("#genre"),
    storyInput: document.querySelector("#story"),
    publishBtn: document.querySelector("#form-btn"),
    previewList: document.querySelector("#preview-list"),
    main: document.querySelector("#main"),
  };

  selectors.publishBtn.addEventListener("click", publish);

  function publish(event) {
    event.preventDefault();
    if (
      selectors.firstNameInput.value === "" ||
      selectors.lastNameInput.value === "" ||
      selectors.ageInput.value === "" ||
      selectors.storyTitleInput.value === "" ||
      selectors.storyInput.value === ""
    ) {
      console.log("wrong input");
      return;
    }

    const storyListItem = createElement(
      "li",
      null,
      ["story-info"],
      null,
      selectors.previewList
    );
    const article = createElement("article", null, null, null, storyListItem);
    const name = createElement(
      "h4",
      `Name: ${selectors.firstNameInput.value} ${selectors.lastNameInput.value}`,
      null,
      null,
      article
    );
    const age = createElement(
      "p",
      `Age: ${selectors.ageInput.value}`,
      null,
      null,
      article
    );
    const title = createElement(
      "p",
      `Title: ${selectors.storyTitleInput.value}`,
      null,
      null,
      article
    );
    const genre = createElement(
      "p",
      `Genre: ${selectors.genreInput.value}`,
      null,
      null,
      article
    );
    const story = createElement(
      "p",
      selectors.storyInput.value,
      null,
      null,
      article
    );

    const saveBtn = createElement(
      "button",
      "Save Story",
      ["save-btn"],
      null,
      storyListItem
    );
    const editBtn = createElement(
      "button",
      "Edit Story",
      ["edit-btn"],
      null,
      storyListItem
    );
    const deleteBtn = createElement(
      "button",
      "Delete  Story",
      ["delete-btn"],
      null,
      storyListItem
    );

    saveBtn.addEventListener("click", saveStory);
    editBtn.addEventListener("click", editStory);
    deleteBtn.addEventListener("click", deleteStory);

    selectors.firstNameInput.value = "";
    selectors.lastNameInput.value = "";
    selectors.ageInput.value = "";
    selectors.storyTitleInput.value = "";
    selectors.storyInput.value = "";
    selectors.publishBtn.disabled = true;
  }

  function saveStory(event) {
    event.preventDefault();
    console.log("save");
    selectors.main.innerHTML = "";
    createElement(
      "h1",
      "Your scary story is saved!",
      null,
      null,
      selectors.main
    );
  }

  function editStory(event) {
    event.preventDefault();

    const storyInfo = {
      storyItem: document.querySelector("#preview-list > li"),
      author: document.querySelector("#preview-list > li > article > h4"),
      age: document.querySelector("#preview-list li article p:nth-child(2)"),
      title: document.querySelector(
        "#preview-list > li > article > p:nth-child(3)"
      ),
      genre: document.querySelector(
        "#preview-list > li > article > p:nth-child(4)"
      ),
      storyText: document.querySelector(
        "#preview-list > li > article > p:nth-child(5)"
      ),
    };

    const nameInfo = storyInfo.author.textContent.split(": ")[1].split(" ");

    const age = storyInfo.age.textContent.split(": ")[1];
    const title = storyInfo.title.textContent.split(": ")[1];
    const storyText = storyInfo.storyText.textContent;

    selectors.firstNameInput.value = nameInfo[0];
    selectors.lastNameInput.value = nameInfo[1];
    selectors.ageInput.value = age;
    selectors.storyTitleInput.value = title;
    selectors.storyInput.value = storyText;
    selectors.genreInput.value = storyInfo.genre.textContent.split(": ")[1];
    selectors.publishBtn.disabled = false;
    storyInfo.storyItem.remove();
  }

  function deleteStory(event) {
    event.preventDefault();
    const storyItem = document.querySelector("#preview-list > li");
    storyItem.remove();
    selectors.publishBtn.disabled = false;
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
