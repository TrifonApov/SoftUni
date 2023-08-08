function editElement(element, textToReplace, replacement) {
    let text = element.textContent;
    
    while (text.includes(textToReplace)){
        text = text.replace(textToReplace, replacement);
    }
    
    element.textContent = text;
}