function focused() {
    const sections = Array.from(document.querySelectorAll("input"));
    
    sections.forEach((section) => {
        section.addEventListener("focus", (e) => {
            e.target.parentElement.classList.add("focused");
        })
        section.addEventListener("blur", (e) => {
            e.target.parentElement.classList.remove("focused");
        })
    })
}