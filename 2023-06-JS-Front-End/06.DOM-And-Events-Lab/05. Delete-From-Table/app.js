function deleteByEmail() {
    const emails = Array.from(document.querySelectorAll("td:nth-child(even)"));
    const input = document.querySelector("input").value;
    
    const mailToDelete = emails.find(mail => mail.textContent === input);
    const result = document.querySelector("#result");

    if (mailToDelete) {
        mailToDelete.parentElement.remove();
        result.textContent = 'Deleted.';
    } else {
        result.textContent = 'Not found.';
    }
}