function addItem() {
    const menu = document.querySelector("#menu");
    const newItemText = document.querySelector("#newItemText");
    const newItemValue = document.querySelector("#newItemValue");
    console.log(newItemText.value);
    console.log(newItemValue.value);
    
    const newOption = document.createElement("option");
    const text = `${newItemText.value} ${newItemValue.value}`;
    newOption.textContent = text;
    menu.appendChild(newOption);

    newItemText.value = '';
    newItemValue.value = '';

}