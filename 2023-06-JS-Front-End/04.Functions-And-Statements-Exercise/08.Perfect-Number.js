function solve (number) {
    let perfectSum = 0;
    for (let i = 0; i < number; i++){
        if (number % i === 0) {
            perfectSum+=i;
        }
    }
    console.log(perfectSum === number ? "We have a perfect number!" : "It's not so perfect.");
}


solve(6);
solve(28);
solve(1236498);