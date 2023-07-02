function solve (x,y) {
    function factorial (n) {
        let result = 1;
        for (let i = 1; i <= n; i++){
            result*=i;
        }
        return result;
    }

    let xFactorial = factorial(x);
    let yFactorial = factorial(y);

    console.log((xFactorial/yFactorial).toFixed(2));
}


solve(5,2);
solve(6,2);

