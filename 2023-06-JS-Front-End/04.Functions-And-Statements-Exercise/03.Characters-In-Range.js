function solve (...range) {
    range.sort();
    let charecters = [];
    for (let i = range[0].charCodeAt(0) + 1; i < range[1].charCodeAt(0); i++){
        charecters.push(String.fromCharCode(i));
    }
    console.log(charecters.join(' '));
}


solve('a','d');
solve('#',':');
solve('C','#');