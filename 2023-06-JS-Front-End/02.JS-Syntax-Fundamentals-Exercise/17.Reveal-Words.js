function solve (inputWords, text) {
    let words = inputWords.split(', ');
    for (const word of words) {
        let search = '*'.repeat(word.length);
        text = text.replace(search,word);
    }
    console.log(text);
}


solve('great, learning', 'softuni is ***** place for ******** new programming languages');