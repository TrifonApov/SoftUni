function addItem() {
    const newItemText = document.querySelector("#newItemText").value;
    
    const newItem = createItem(newItemText);
    
    document.querySelector("ul").appendChild(newItem);

    function createItem(text) {
        const item = document.createElement("li");
        item.textContent = text;
        item.appendChild(createDeleteButton());

        return item;
    }

    function createDeleteButton(){
        const deleteButton = document.createElement("a");
        deleteButton.href = "#";
        deleteButton.textContent = "[Delete]";
        deleteButton.addEventListener("click", e => e.target.parentElement.remove());

        return deleteButton;
    }
}