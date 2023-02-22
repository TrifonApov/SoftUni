function solve(input) {
    var maxSum = -1000020;
    var maxValues = [];
    var result;
    for (var i = 2; i < input.length-1; i++) {
        var allNumFromInput;
        var currNum = input[i].match(/[0-9.-]+/g);
        allNumFromInput = currNum;

        var allCurrNum = [];
        for (var j = 0; j < allNumFromInput.length; j++) {
            allCurrNum[j]=parseFloat(allNumFromInput[j]);
        }

        var sum = 0;
        for (var k = 0; k < allCurrNum.length; k++) {
            if (!isNaN(allCurrNum[k])) {
                sum+=allCurrNum[k];
            }

        }
        if (sum > maxSum) {
            maxSum = sum;
            maxValues=allNumFromInput;
        }

    }
    result = maxSum;
    if (result === -1000020 || (result == 0 && maxValues[0] === '-' && maxValues[1] === '-' && maxValues[2] === '-')) {
        result = 'no data';
    } else {
        result+=' = ';
        for (var i = 0; i < maxValues.length; i++) {
            if (maxValues[i]!=='-') {
                result += maxValues[i] + ' + ';
            }
        }
        result = result.slice(0, result.length - 3);
    }
console.log(result);
    return result;
}

solve(['<table>',
        '<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
        '<tr><td>Yambol</td><td>-</td><td>-</td><td>-</td></tr>',
        '<tr><td>Sofia</td><td>-</td><td>-</td><td>-</td></tr>',
        '<tr><td>Sliven</td><td>-</td><td>-</td><td>-</td></tr>',
        '<tr><td>Kaspichan</td><td>-</td><td>-</td><td>-</td></tr>',
        '</table>']
);