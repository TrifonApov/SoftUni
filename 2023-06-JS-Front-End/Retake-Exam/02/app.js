window.addEventListener("load", solve);

function solve() {
  const inputSelectors = {
    playerName: document.querySelector("#player"),
    score: document.querySelector("#score"),
    round: document.querySelector("#round"),
  };
  const selectors = {
    sureList: document.querySelector("#sure-list"),
    addBtn: document.querySelector("#add-btn"),
    clearBtn: document.querySelector("#players-container > div > div > button"),
  };

  selectors.addBtn.addEventListener("click", addPlayer);

  function addPlayer(event) {
    event.preventDefault();
    if (
      !inputSelectors.playerName.value ||
      !inputSelectors.score.value ||
      !inputSelectors.round.value
    ) {
      console.log("Missing data");
      return;
    }

    const dartItem = createElement(
      "li",
      null,
      ["dart-item"],
      null,
      selectors.sureList
    );
    const article = createElement("article", null, null, null, dartItem);
    const name = createElement(
      "p",
      inputSelectors.playerName.value,
      null,
      null,
      article
    );
    const score = createElement(
      "p",
      `Score: ${inputSelectors.score.value}`,
      null,
      null,
      article
    );
    const round = createElement(
      "p",
      `Round: ${inputSelectors.round.value}`,
      null,
      null,
      article
    );

    const editBtn = createElement(
      "button",
      "edit",
      ["btn", "edit"],
      null,
      dartItem
    );
    editBtn.addEventListener("click", edit);
    const okBtn = createElement("button", "ok", ["btn", "ok"], null, dartItem);
    okBtn.addEventListener("click", ok);

    inputSelectors.playerName.value = "";
    inputSelectors.score.value = "";
    inputSelectors.round.value = "";
    selectors.addBtn.disabled = true;
  }

  function edit(event) {
    const dartItem = document.querySelector("#sure-list > li");
    const name = document.querySelector(
      "#sure-list > li > article > p:nth-child(1)"
    ).textContent;
    const score = document
      .querySelector("#sure-list > li > article > p:nth-child(2)")
      .textContent.split(": ");
    const round = document
      .querySelector("#sure-list > li > article > p:nth-child(3)")
      .textContent.split(": ");

    inputSelectors.playerName.value = name;
    inputSelectors.score.value = score[1];
    inputSelectors.round.value = round[1];
    selectors.addBtn.disabled = false;

    dartItem.remove();
  }

  function ok(event) {
    const dartItem = document.querySelector("#sure-list > li");
    const editBtn = document.querySelector("#sure-list > li > button.btn.edit");
    const okBtn = document.querySelector("#sure-list > li > button.btn.ok");
    editBtn.remove();
    okBtn.remove();
    dartItem.remove();
    document.querySelector("#scoreboard-list").appendChild(dartItem);
    selectors.addBtn.disabled = false;
  }

  selectors.clearBtn.addEventListener("click", (event) => {
    event.preventDefault();
    window.location.reload();
  });

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
