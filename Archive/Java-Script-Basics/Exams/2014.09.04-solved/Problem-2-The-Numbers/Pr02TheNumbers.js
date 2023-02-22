function solve(input) {
    var numbers = input[0].match(/\d+/g);
    var numbersInHex = [];
    for (var i = 0; i < numbers.length; i++) {
        numbersInHex[i] = parseInt(numbers[i]).toString(16).toUpperCase();
    }
    for (var num in numbersInHex) {
        numbersInHex[num] = paddingLeft(numbersInHex[num], 4);
    }

    function paddingLeft(num, size) {
        var s = "0000" + num;
        return s.substr(s.length-size);
    }
    var result = '';
    for (var i = 0; i < numbersInHex.length; i++) {
        result += '0x' + numbersInHex[i] + '-';
    }
    return result.slice(0,result.length-1);
}

console.log(solve(['482vMWo(*&^%$213;k!@41341((()&^>><///]42344p;e312']));