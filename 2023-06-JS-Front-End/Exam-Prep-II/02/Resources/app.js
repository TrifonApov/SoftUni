window.addEventListener("load", solve);

function solve() {
  const inputFields = {
    genre: document.querySelector("#genre"),
    songName: document.querySelector("#name"),
    author: document.querySelector("#author"),
    date: document.querySelector("#date"),
  };

  const selectors = {
    allHitsContainer: document.querySelector("#all-hits > div"),
    addBtn: document.querySelector("#add-btn"),
    saveSongBtn: document.querySelector(
      "#all-hits > div > div > button.save-btn"
    ),
    likeSongBtn: document.querySelector(
      "#all-hits > div > div > button.like-btn"
    ),
    deleteBtn: document.querySelector(
      "#all-hits > div > div > button.delete-btn"
    ),
  };

  selectors.addBtn.addEventListener("click", (e) => {
    e.preventDefault();
    if (Object.values(inputFields).some((p) => !p.value)) {
      console.log("kofti input maina");
      return;
    }

    const songContainer = createElement(
      "div",
      null,
      ["hits-info"],
      null,
      selectors.allHitsContainer
    );

    const img = createElement("img");
    img.setAttribute("src", "./static/img/img.png");
    songContainer.appendChild(img);

    const genre = createElement(
      "h2",
      `Genre: ${inputFields.genre.value}`,
      null,
      null,
      songContainer
    );
    const songName = createElement(
      "h2",
      `Name: ${inputFields.songName.value}`,
      null,
      null,
      songContainer
    );
    const author = createElement(
      "h2",
      `Author: ${inputFields.author.value}`,
      null,
      null,
      songContainer
    );
    const date = createElement(
      "h3",
      `Date: ${inputFields.date.value}`,
      null,
      null,
      songContainer
    );

    const saveBtn = createElement(
      "button",
      "Save song",
      ["save-btn"],
      null,
      songContainer
    );
    saveBtn.addEventListener("click", saveSong);

    const likeBtn = createElement(
      "button",
      "Like song",
      ["like-btn"],
      null,
      songContainer
    );
    likeBtn.addEventListener("click", likeSong);

    const deleteBtn = createElement(
      "button",
      "Delete",
      ["delete-btn"],
      null,
      songContainer
    );
    deleteBtn.addEventListener("click", deleteSong);
  });

  function likeSong(event) {
    const likes =
      Number(
        document
          .querySelector("#total-likes > div > p")
          .textContent.split(": ")[1]
      ) + 1;
    document.querySelector(
      "#total-likes > div > p"
    ).textContent = `Total Likes: ${likes}`;
    event.target.disabled = true;
  }

  function saveSong(event) {
    const song = event.target.parentElement;
    console.log(song);
    song.children[5].remove();
    song.children[5].remove();
    song.remove();

    document.querySelector("#saved-hits > div").appendChild(song);
  }

  function deleteSong(event) {
    const song = event.target.parentElement;
    song.remove();
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
