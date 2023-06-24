function solve (number) {
    let digits = String(number).split('').map(Number);
    let sum = 0;
    for (const digit of digits) {
        sum += digit;
    }
    
    const allEqual = digits.every(element => {
        if (element === digits[0]) {
          return true;
        }
      });

    console.log(allEqual);
    console.log(sum);
}


solve(2222222);
solve(1234);