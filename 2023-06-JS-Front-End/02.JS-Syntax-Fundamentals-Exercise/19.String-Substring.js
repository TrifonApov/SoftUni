function solve (search, text) {
    let splited = text.split(' ');
    for (const word of splited) {
        if (search.toLowerCase() === word.toLowerCase()) {
            console.log(search);
            return;
        }
    }
    console.log(`${search} not found!`);
}


solve('javascript', 'JavaScript is the best programming language');
solve('python', 'JavaScript is the best programming language');