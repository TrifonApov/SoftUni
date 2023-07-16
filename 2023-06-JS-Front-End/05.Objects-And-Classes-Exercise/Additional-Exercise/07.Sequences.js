function solve (input) {
    const set = new Set();
    input.forEach(element => {
        if(!set.has(JSON.stringify(JSON.parse(element).sort((a,b) => b - a)))){
            set.add(JSON.stringify(JSON.parse(element).sort((a,b) => b - a)));
        }
    });
    
    Array.from(set)
        .sort((a,b) => a.length - b.length)
        .forEach(arr => {

            console.log(`[${JSON.parse(arr).join(', ')}]`);
        });
    
}

solve([
    "[-13, -2, -51, 15.99, 21, 21, 3.76, 4]",
    "[110, 1.98, -317, 0, 2, 13]",
    "[4, -3, 3, -2, 2, -1, 1, 0]",
    "[1, 4, 2, 5, 0, -5]",
    "[2, 4, 1, 5, 0, -5]"
])


// solve(["[7.14, 7.180, 7.339, 80.099]",
// "[7.339, 80.0990, 7.140000, 7.18]",
// "[7.339, 7.180, 7.14, 80.099]"]);