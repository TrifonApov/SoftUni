function addItem() {
    const node = document.createElement("li");
    const textnode = document.createTextNode(document.getElementById('newItemText').value);
    node.appendChild(textnode);
    document.getElementById("items").appendChild(node);
}