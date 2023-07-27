function sumTable() {
    const numbers = Array.from(document.querySelectorAll("td:nth-child(even)"));
    const result = numbers.reduce((acc, curr) => {
        acc+= Number(curr.textContent);
        return acc;
    }, 0);
    document.querySelector("#sum").textContent = result;
    console.log(result);
}