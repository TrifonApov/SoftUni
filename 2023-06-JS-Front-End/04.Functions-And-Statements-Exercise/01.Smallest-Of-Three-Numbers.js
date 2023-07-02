function solve (...numbers) {
    console.log(Math.min.apply(Math, numbers));
}


solve(2,5,3);
solve(600,342,123);
solve(25,21,4);
solve(2,2,2);