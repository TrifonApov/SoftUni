function extractText() {
    const listItems = document.querySelectorAll("ul#items li");
    
    let textArea = document.querySelector("#result");

    for (const item of listItems) {
        textArea.value += item.textContent + '\n';
    }
}