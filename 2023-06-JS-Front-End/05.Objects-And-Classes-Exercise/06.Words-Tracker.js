function solve (input) {
    const [searchWords, ...words] = input;
    const occurrences = searchWords.split(' ').reduce((acc, current) => {
        acc[current] = 0;
        return acc;
    },{});
    
    words.forEach(word => {
        if(occurrences.hasOwnProperty(word)){
            occurrences[word]++;
        }
    });
    
    
    Object.entries(occurrences)
    .sort((a, b) => b[1] - a[1])
    .forEach(word => console.log(`${word[0]} - ${word[1]}`));
}


solve([
    'this sentence',
    'In', 'this', 'sentence', 'you', 'have',
    'to', 'count', 'the', 'occurrences', 'of',
    'the', 'words', 'this', 'and', 'sentence',
    'because', 'this', 'is', 'your', 'task'
    ]);

solve([
    'is the',
    'first', 'sentence', 'Here', 'is',
    'another', 'the', 'And', 'finally', 'the',
    'the', 'sentence']);