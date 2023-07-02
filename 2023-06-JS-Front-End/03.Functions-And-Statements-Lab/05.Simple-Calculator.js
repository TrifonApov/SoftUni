function solve(num1, num2, operator) {
    const calculator = {
        multiply: (a, b) => a * b,
        divide: (a, b) => a / b,
        add: (a, b) => a + b,
        subtract: (a, b) => a - b,
    }

    console.log(calculator[operator](num1,num2));
}


solve(5,5,'multiply');
solve(40,8,'divide');
solve(12,19,'add');
solve(50,13,'subtract');