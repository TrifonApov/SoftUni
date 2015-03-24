function solve(input){
    var playGround = [];
    for (var i = 0; i < input.length; i++) {
        playGround[i] = input[i];
    }

    var result = {
        I: countI(playGround),
        L: countL(playGround),
        J: countJ(playGround),
        O: countO(playGround),
        Z: countZ(playGround),
        S: countS(playGround),
        T: countT(playGround)};
    function countI(checkI) {
        var countI = 0;
        for (var row = 0; row < checkI.length - 3; row++) {
            for (var col = 0; col < checkI[row].length; col++) {
                if (checkI[row][col] === 'o' &&
                    checkI[row][col] === checkI[row + 1][col] &&
                    checkI[row][col] === checkI[row + 2][col] &&
                    checkI[row][col] === checkI[row + 3][col]){
                    countI++;
                }
            }
        }
        return countI;
    }
    function countL(checkL) {
        var countL = 0;
        for (var row = 0; row < checkL.length - 2; row++) {
            for (var col = 0; col < checkL[row].length - 1; col++) {
                if (checkL[row][col] == 'o' &&
                    checkL[row][col] == checkL[row + 1][col] &&
                    checkL[row][col] == checkL[row + 2][col] &&
                    checkL[row][col] == checkL[row + 2][col + 1]) {
                    countL++;
                }
            }
        }
        return countL;
    }
    function countJ(checkJ) {
        var countJ = 0;
        for (var row = 0; row < checkJ.length - 2; row++) {
            for (var col = 1; col < checkJ[row].length; col++) {
                if (checkJ[row][col] == 'o' &&
                    checkJ[row][col] == checkJ[row + 1][col] &&
                    checkJ[row][col] == checkJ[row + 2][col] &&
                    checkJ[row][col] == checkJ[row + 2][col - 1]) {
                    countJ++;
                }
            }
        }
        return countJ;
    }
    function countO(checkO) {
        var countO = 0;
        for (var row = 0; row < checkO.length - 1; row++) {
            for (var col = 0; col < checkO[row].length - 1; col++) {
                if (checkO[row][col] == 'o' &&
                    checkO[row][col] == checkO[row][col + 1] &&
                    checkO[row][col] == checkO[row + 1][col] &&
                    checkO[row][col] == checkO[row + 1][col + 1])
                {
                    countO++;
                }
            }
        }
        return countO;
    }
    function countZ(checkZ) {
        var countZ = 0;
        for (var row = 0; row < checkZ.length - 1; row++) {
            for (var col = 0; col < checkZ[row].length - 2; col++){
                if (checkZ[row][col] == 'o' &&
                    checkZ[row][col] == checkZ[row][col + 1] &&
                    checkZ[row][col] == checkZ[row + 1][col + 1] &&
                    checkZ[row][col] == checkZ[row + 1][col + 2]){
                    countZ++;
                }
            }
        }
        return countZ;
    }
    function countS(checkS) {
        var countS = 0;
        for (var row = 0; row < checkS.length - 1; row++) {
            for (var col = 0; col < checkS[row].length - 2; col++){
                if (checkS[row][col + 1] == 'o' &&
                    checkS[row][col + 1] == checkS[row][col + 2] &&
                    checkS[row][col + 1] == checkS[row + 1][col] &&
                    checkS[row][col + 1] == checkS[row + 1][col + 1]) {
                    countS++;
                }
            }
        }
        return countS;
    }
    function countT(checkT) {
        var countT = 0;
        for (var row = 0; row < checkT.length - 1; row++) {
            for (var col = 0; col < checkT[row].length - 2; col++){
                if (checkT[row][col] == 'o' &&
                    checkT[row][col] == checkT[row][col + 1] &&
                    checkT[row][col] == checkT[row][col + 2] &&
                    checkT[row][col] == checkT[row + 1][col + 1]){
                    countT++;
                }
            }
        }
        return countT;
    }

    return JSON.stringify(result);
}



console.log(solve(['--o--o-',
       '--oo-oo',
       'ooo-oo-',
       '-ooooo-',
       '---oo--']));


