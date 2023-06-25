function solve (string) {
    let words = [];
    let upperCasePosition = 0;

    for(let i = 1; i < string.length; i++){
        if (string[i] === string[i].toUpperCase()){
            words.push(string.substring(upperCasePosition, i))
            upperCasePosition = i;
        }
    }
    words.push(string.substring(upperCasePosition));
    console.log(words.join(', '));
}
// function solve(word) {
//     let result = [];
//     let start = 0;
//     for (let i = 1; i < word.length; i++) {
//       if (word[i] === word[i].toUpperCase()) {
//         result.push(word.substring(start, i));
//         start = i;
//       }
//     }
//     result.push(word.substring(start)); 
//     console.log(result.join(', '));
//     }

solve('SplitMeIfYouCanHaHaYouCantOrYouCan');
solve('HoldTheDoor');
solve('ThisIsSoAnnoyingToDo');