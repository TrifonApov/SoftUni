function solve (number) {
    let bar = `${number}% [${'%'.repeat(number/10)}${'.'.repeat(10 - number/10)}]`;
    
    if (number < 100) {
        console.log(bar);
        console.log(`Still loading...`);
    } else {
        console.log(`100% Complete!`);
        console.log(bar.trimStart('100% '));
    }
}


solve(30);
solve(50);
solve(100);