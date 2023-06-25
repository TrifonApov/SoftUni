function solve (array, rotation) {
    for (let i = 0; i < rotation; i++) {
        let element = array.shift();
        array.push(element);
    }

    console.log(array.join(' '));
}


solve([51, 47, 32, 61, 21], 2);
solve([32, 21, 61, 1], 4);