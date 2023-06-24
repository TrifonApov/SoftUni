function solve (radius) {
    let typeOfArgument = typeof(radius);
    if (typeOfArgument === 'number') {
        console.log((Math.PI*radius**2).toFixed(2));
    }
    else{
        console.log(`We can not calculate the circle area, because we receive a ${typeOfArgument}.`)
    }
}


solve(5)