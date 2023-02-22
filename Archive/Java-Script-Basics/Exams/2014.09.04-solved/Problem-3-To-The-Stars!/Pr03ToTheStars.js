function solve(input) {
    var firstGal = input[0].split(/\s+/),
        secondGal = input[1].split(/\s+/),
        thirdGal = input[2].split(/\s+/),
        normandy = input[3].split(/\s+/),
        normandyX = parseFloat(normandy[0]),
        normandyY = parseFloat(normandy[1]);
    var firstCenterX = parseFloat(firstGal[1]),
        firstCenterY = parseFloat(firstGal[2]);
    var secondCenterX = parseFloat(secondGal[1]),
        secondCenterY = parseFloat(secondGal[2]);
    var thirdCenterX = parseFloat(thirdGal[1]),
        thirdCenterY = parseFloat(thirdGal[2]);
    var turns = parseInt(input[4]);
    var result = [];
    for (var i =0; i <= turns; i++) {
        if (normandyX >= firstCenterX - 1.0 && normandyX <= firstCenterX + 1.0 &&
            normandyY + i >= firstCenterY - 1.0 && normandyY + i <= firstCenterY + 1.0) {
            result[i] = firstGal[0].toLowerCase();
        } else if (normandyX >= secondCenterX - 1.0 && normandyX <= secondCenterX + 1.0 &&
            normandyY + i >= secondCenterY - 1.0 && normandyY + i <= secondCenterY + 1.0) {
            result[i] = secondGal[0].toLowerCase();
        } else if (normandyX >= thirdCenterX - 1.0 && normandyX <= thirdCenterX + 1.0 &&
            normandyY + i >= thirdCenterY - 1.0 && normandyY + i <= thirdCenterY + 1.0) {
            result[i] = thirdGal[0].toLowerCase();
        } else {
            result[i] = 'space';
        }
    }
    var output = '';
    for (var i = 0; i < result.length; i++) {
        output+=result[i] + '\n';
    }
    return output
}
console.log(solve(['starGemini 13.1 28.2',
    'starCanesLupus 13.5 14.9 ',
    'starIpsum 12.8 7.5 ',
    '12.7 6.2',
    '21']));