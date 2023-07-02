function solve (number) {
    let oddSum = 0;
    let evenSum = 0;

    let digits = String(number).split('').map(Number);

    for (const digit of digits) {
        if (digit % 2 === 0) {
            evenSum+=digit;
        } else {
            oddSum+=digit;
        }
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}


solve(1000435);
solve(3495892137259234);