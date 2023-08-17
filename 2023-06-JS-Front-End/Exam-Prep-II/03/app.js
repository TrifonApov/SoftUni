const BASE_URL = "http://localhost:3030/jsonstore/grocery/";
const selectors = {
  addProductBtn: document.querySelector("#add-product"),
  updateProductBtn: document.querySelector("#update-product"),
  loadProductsBtn: document.querySelector("#load-product"),
  tableBody: document.querySelector("#tbody"),
};
const inputSelectors = {
  productName: document.querySelector("#product"),
  count: document.querySelector("#count"),
  price: document.querySelector("#price"),
};
let productToUpdateId = "";

selectors.loadProductsBtn.addEventListener("click", loadProductHandler);
function loadProductHandler(event) {
  if (event) {
    event.preventDefault();
  }

  fetch(BASE_URL)
    .then((res) => res.json())
    .then((products) => {
      selectors.tableBody.innerHTML = "";
      Object.values(products).forEach((product) => {
        const productRow = createElement(
          "tr",
          null,
          null,
          [product["_id"]],
          selectors.tableBody
        );
        const nameCell = createElement(
          "td",
          product["product"],
          ["name"],
          null,
          productRow
        );
        const countCell = createElement(
          "td",
          product["count"],
          ["count-procuct"],
          null,
          productRow
        );
        const priceCell = createElement(
          "td",
          product["price"],
          ["name"],
          null,
          productRow
        );

        const buttonsCell = createElement(
          "td",
          null,
          ["btn"],
          null,
          productRow
        );
        const updateBtn = createElement(
          "button",
          "Update",
          ["update"],
          null,
          buttonsCell
        );
        updateBtn.addEventListener("click", updateProduct);

        const deleteBtn = createElement(
          "button",
          "Delete",
          ["delete"],
          null,
          buttonsCell
        );
        deleteBtn.addEventListener("click", deleteProduct);
      });
    });
}

selectors.addProductBtn.addEventListener("click", addProductHandler);
function addProductHandler(event) {
  event.preventDefault();

  if (Object.values(inputSelectors).some((p) => !p.value)) {
    console.log("invalid data");
    return;
  }
  const newProduct = {
    product: inputSelectors.productName.value,
    count: inputSelectors.count.value,
    price: inputSelectors.price.value,
  };
  fetch(BASE_URL, {
    method: "POST",
    body: JSON.stringify(newProduct),
  })
    .then(() => {
      inputSelectors.productName.value = "";
      inputSelectors.count.value = "";
      inputSelectors.price.value = "";
      loadProductHandler();
    })
    .catch(console.error());
}

selectors.updateProductBtn.addEventListener("click", updateProductHandler);
function updateProductHandler(event) {
  event.preventDefault();
  const product = {};
  product["product"] = inputSelectors.productName.value;
  product["count"] = inputSelectors.count.value;
  product["price"] = inputSelectors.price.value;

  fetch(`${BASE_URL}${productToUpdateId}`, {
    method: "PATCH",
    body: JSON.stringify(product),
  }).then(() => {
    selectors.updateProductBtn.disabled = true;
    selectors.addProductBtn.disabled = false;

    inputSelectors.productName.value = "";
    inputSelectors.count.value = "";
    inputSelectors.price.value = "";
    loadProductHandler();
  });
}

function updateProduct(event) {
  event.preventDefault();
  const productInfo = event.target.parentElement.parentElement.children;
  productToUpdateId = event.target.parentElement.parentElement.id;
  console.log(productToUpdateId);
  inputSelectors.productName.value = productInfo[0].textContent;
  inputSelectors.count.value = productInfo[1].textContent;
  inputSelectors.price.value = productInfo[2].textContent;
  selectors.updateProductBtn.disabled = false;
  selectors.addProductBtn.disabled = true;
}

function deleteProduct(event) {
  event.preventDefault();
  productToUpdateId = event.target.parentElement.parentElement.id;
  fetch(`${BASE_URL}${productToUpdateId}`, { method: "DELETE" })
    .then(() => loadProductHandler())
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
