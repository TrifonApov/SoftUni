function solve (str, word){
    let stars = '*'.repeat(word.length);
    
    while(str.includes(word)){
        str = str.replace(word, stars);
    }
    console.log(str);
}


solve('soallsentencewithsomewords', 'so');
solve('Find the hidden word', 'hidden' );