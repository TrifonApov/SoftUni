function solve (...numbers) {
    let countNegative = 0;
    numbers.forEach(n => {
        if (n<0) {
            countNegative++;
        }
    });

    console.log(countNegative%2 == 0 ? 'Positive' : 'Negative');
}


solve(5, 12, -15);
solve(-6, -12, 14);
solve(-1, -2, -3);