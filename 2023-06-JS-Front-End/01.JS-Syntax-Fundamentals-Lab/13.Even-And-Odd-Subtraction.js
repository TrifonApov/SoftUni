function solve (array){
    let oddSum = 0;
    let evenSum = 0;
    
    for (let number of array) {
        if (number % 2 === 0) {
            evenSum+=number;
        } else {
            oddSum+=number;
        }
    }

    console.log(evenSum-oddSum);
}

solve([1, 2, 3, 4, 5, 6]);
solve([3, 5, 7, 9]);
solve([2, 4, 6, 8, 10]);