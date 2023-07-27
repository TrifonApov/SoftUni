function toggle() {
    const button = document.querySelector(".button");
    
    if (button.textContent.toLowerCase() === 'more') {
        button.textContent = 'Less';
        document.querySelector("#extra").style.display = 'block';
        
    } else {
        button.textContent = 'More';
        document.querySelector("#extra").style.display = 'none';
    }
}