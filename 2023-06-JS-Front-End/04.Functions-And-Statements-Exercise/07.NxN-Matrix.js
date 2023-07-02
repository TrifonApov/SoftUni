function solve (n) {
    let matrix = [];
    for (let i = 0; i < n; i++){
        matrix[i] = new Array();
        
        for (let j = 0; j < n; j++){
            matrix[i].push(n);
        }
    }

    matrix.forEach(row => console.log(row.join(' ')));
}


solve(3);
solve(7);
solve(2);