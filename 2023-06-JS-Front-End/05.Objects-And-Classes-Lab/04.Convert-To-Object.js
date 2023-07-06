function solve (string) {
    let person = JSON.parse(string);

    let info = Object.entries(person);
    for (const [key, value] of info) {
        console.log(`${key}: ${value}`);
    }
}
