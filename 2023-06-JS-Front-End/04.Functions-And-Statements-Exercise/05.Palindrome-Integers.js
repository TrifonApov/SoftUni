function solve (numbers) {
    for (const number of numbers) {
        let numberAsString = number.toString().split("").reverse().join("");
        let reversedNumber = numberAsString.split("").reverse().join("");
        
        console.log(numberAsString === reversedNumber)
    }
}


// solve([123,323,421,121]);
solve([32,2,232,1010]);