function solve(input) {
    var bill = parseFloat(input[0]), mood = input[1];
    var tip;
    switch (mood) {
        case 'happy':
            tip = bill*0.1;
            break;
        case 'married':
            tip = bill*0.0005;
            break;
        case 'drunk':
            var fifteenPerTip = (bill*0.15).toString();
            var firstDigit = parseInt(fifteenPerTip[0]);
            tip = Math.pow(parseFloat(fifteenPerTip), firstDigit);
            break;
        default:
            tip = bill*0.05
            break;
    }

    return tip.toFixed(2);
}

solve([120.44, 'happy'])
solve([1230.83, 'drunk'])
solve([200, 'married'])

//When happy, don Vlado tips for 10% of the bill

//When married, don Vlado tips for 0.05% of the bill

//When drunk, don Vlado tips for (15% of the bill)n, where n is the first digit of the tip.
//  (e.g. if the bill is 200, 30 is 15% of the bill. 3 is the first digit of 30,
//  so Don Vlado leaves the tip 303 = 30 * 30 * 30 = 27000)

//In every other scenario, don Vlado is simply grumpy and tips for only 5% of the bill