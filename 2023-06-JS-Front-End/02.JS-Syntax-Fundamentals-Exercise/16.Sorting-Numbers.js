function solve (array) {
    let ascending = array.slice().sort(function(a, b){return a-b});
    
    let result = [];
    let count = 0;
    
    while (ascending.length > 0) {
        if (count % 2 === 0) {
            result.push(ascending.shift());
        } else {
            result.push(ascending.pop());
        }
        count++;
    }
    return result;
}


solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);