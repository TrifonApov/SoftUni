function solve (n1, operator, n2) {
    switch (operator) {
        case '+':
            console.log((n1+n2).toFixed(2));
            break;
        case '-':
            console.log((n1-n2).toFixed(2));
            break;
        case '*':
            console.log((n1*n2).toFixed(2));
            break;
        case '/':
            console.log((n1/n2).toFixed(2));
            break;
    }
}


solve(5,'+',10);
solve(25.5,'-',3);
solve(2.5,'*',15);
solve(100,'/',21);