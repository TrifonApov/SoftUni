function solve (string) {
    let words = string.match(/\b(\w+)\b/g);
    for (let i = 0; i < words.length; i++){
        words[i] = words[i].toUpperCase();
    }

    console.log(words.join(', '));
}


solve('Hi, how are you?');
solve('hello');