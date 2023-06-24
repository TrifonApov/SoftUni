function solve (start, end) {
    let array = [];
    let sum = 0;
    for (let i = start; i <= end; i++) {
        const element = array[i];
        array.push(i);
        sum+=i;
    }

    console.log(array.join(' '));
    console.log(`Sum: ${sum}`);
}


solve(5,10);
solve(0,26);
solve(50,60);