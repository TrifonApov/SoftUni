function solve(input) {
    var prices = input.map(rounded);
    var result = '<table>' + '\n' +
        '<tr><th>Price</th><th>Trend</th></tr>' + '\n' +
        '<tr><td>' + prices[0] + '</td><td><img src="fixed.png"/></td></td>' + '\n';

    function rounded(element) {
        return (Math.round(element*100)/100).toFixed(2);
    }

    for (var i = 1; i < prices.length; i++) {
        if (parseFloat(prices[i]) === parseFloat(prices[i-1])) {
            result += '<tr><td>' + prices[i] + '</td><td><img src="fixed.png"/></td></td>' + '\n';
        }
        else if (parseFloat(prices[i]) > parseFloat(prices[i-1])) {
            result += '<tr><td>' + prices[i] + '</td><td><img src="up.png"/></td></td>' + '\n';
        } else if (parseFloat(prices[i]) < parseFloat(prices[i-1])) {
            result += '<tr><td>' + prices[i] + '</td><td><img src="down.png"/></td></td>' + '\n';
        }
        
    }
    //console.log(result + '</table>');
    return result + '</table>';
}

console.log(solve([1.33,
    1.35,
    2.25,
    13.00,
    0.5,
    0.51,
    0.5,
    0.5,
    0.33,
    1.05,
    1.346,
    20,
    900,
    1500.1,
    1500.10,
    2000
]));