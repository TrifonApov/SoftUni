function solve (number) {
    let digits = String(number).split('').map(Number);

    let sum = 0;
    for (const digit of digits) {
        sum+=digit;
    }
    console.log(sum);
}


solve(245678);
solve(97561);
solve(543);