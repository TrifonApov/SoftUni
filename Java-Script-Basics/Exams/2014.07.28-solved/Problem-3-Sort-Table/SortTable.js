function solve(input) {
    var result = input[0] + '\n' + input[1] + '\n';
    var arrToSort = [];
    for (var i = 2; i < input.length-1; i++) {
        arrToSort[i-2] = input[i];
    }
    arrToSort = arrToSort.sort(function (curr, next) {
        var currNum = curr.match(/>([\d.])+/g);
        var nextNum = next.match(/>([\d.])+/g);
        var currName = curr.match(/td>([\w\d.\s]+)/g);
        var nextName = next.match(/td>([\w\d.\s]+)/g);
        currNum[0] = parseFloat(currNum[0].replace('>', ''));
        nextNum[0] = parseFloat(nextNum[0].replace('>', ''));
        currName[0] = currName[0].replace('td>', '');
        nextName[0] = nextName[0].replace('td>', '');

        if (currNum[0] !== nextNum[0]) {
            return currNum[0] - nextNum[0];
        } else {
            return currName[0] === nextName[0] ? 0 : currName[0] < nextName[0] ? -1 : 1;
        }
        });
    for (var elem in arrToSort) {
        result+=arrToSort[elem] + '\n';
    }
    result +='</table>';
    return result;

}
//solve(['<table>',
//'<tr><th>Product</th><th>Price</th><th>Votes</th></tr>',
//'<tr><td>Vodka Finlandia 1 l</td><td>19.35</td><td>+12</td></tr>',
//'<tr><td>Ariana Radler 0.5 l</td><td>1.19</td><td>+33</td></tr>',
//'<tr><td>Laptop HP 250 G2</td><td>629</td><td>+1</td></tr>',
//'<tr><td>Kamenitza Grapefruit 1 l</td><td>1.85</td><td>+7</td></tr>',
//'<tr><td>Ariana Grapefruit 1.5 l</td><td>1.85</td><td>+7</td></tr>',
//'<tr><td>Coffee Davidoff 250 gr.</td><td>11.99</td><td>+11</td></tr>',
//'</table>']);

solve(['<table>',
    '<tr><th>Product</th><th>Price</th><th>Votes</th></tr>',
    '<tr><td>Kamenitza Grapefruit 1 l</td><td>1.85</td><td>+7</td></tr>',
    '<tr><td>Vodka Finlandia 1 l</td><td>19.35</td><td>+12</td></tr>',
    '<tr><td>Laptop Lenovo IdeaPad B5400</td><td>929.00</td><td>0</td></tr>',
    '<tr><td>Laptop ASUS ROG G550JK-CN268D</td><td>1939.00</td><td>+1</td></tr>',
    '<tr><td>Ariana Radler 0.5 l</td><td>1.19</td><td>+33</td></tr>',
    '<tr><td>Coffee Davidoff 250 gr.</td><td>11.99</td><td>+11</td></tr>',
    '<tr><td>Kamenitza Lemon 1 l</td><td>1.65</td><td>+7</td></tr>',
    '<tr><td>Vodka Absolute 1 l</td><td>22.00</td><td>+2</td></tr>',
    '<tr><td>Laptop Dell Inspiron 3537</td><td>1199.0</td><td>+3</td></tr>',
    '<tr><td>Laptop HP 250 G2</td><td>629</td><td>-10</td></tr>',
    '<tr><td>Ariana Radler 1.5 l</td><td>2.79</td><td>+33</td></tr>',
    '<tr><td>Coffee Lavazza 250 gr.</td><td>8.73</td><td>+10</td></tr>',
    '</table>']);