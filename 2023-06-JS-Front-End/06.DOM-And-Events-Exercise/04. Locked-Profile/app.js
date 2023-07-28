function lockedProfile() {
    const users = Array.from(document.querySelectorAll(".profile"));
    
    users.forEach(user => {
        const button = user.children[10];
        button.addEventListener('click', (e) =>{
            const previousElementSibling = e.target.previousElementSibling;
            if (button.textContent === "Show more" && user.children[4].checked) {
                previousElementSibling.style.display = "block";
                button.textContent = "Hide it"
            } else {
                if (user.children[4].checked) {
                    previousElementSibling.style.display = "none";
                    button.textContent = "Show more"
                }
            }
            
        });
    })
}