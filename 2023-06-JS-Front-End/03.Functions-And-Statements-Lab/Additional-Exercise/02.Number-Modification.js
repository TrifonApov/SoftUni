function solve (number) {
    let digits = number.toString().split('').map(Number);
    let average = getAvg(digits);
    
    while (average <= 5) {
        digits.push(9);
        average = getAvg(digits);
    }

    console.log(digits.join(''));

    function getAvg(digits) {
        return digits.reduce((a, b) => a + b, 0) / digits.length;
    }
}


solve(101);
solve(5835);