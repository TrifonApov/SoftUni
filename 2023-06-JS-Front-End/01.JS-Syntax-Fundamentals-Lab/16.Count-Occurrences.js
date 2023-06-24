function solve (str, word) {
    let split = str.split(' ');
    let count = 0;
    for (const w of split) {
        if (w=== word) {
            count++;
        }
    }
    console.log(count);
}


solve('This is a word and it also is a sentence', 'is');
solve('softuni is great place for learning new programming languages', 'softuni');