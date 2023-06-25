function solve (string) {
    let regex = /(#[a-zA-Z]+\b)/g;
    const array = [...string.matchAll(regex)];
    for (const match of array) {
        console.log(match[0].substring(1));
    }
    
}


solve('Nowadays everyone uses # to tag a #special word in #socialMedia');
solve('The symbol # is known #variously in English-speaking #regions as the #number sign');