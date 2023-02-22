function solve(input) {
    var matrix = [];
    for (var i = 1; i < input.length; i++) {
        matrix[i-1] = input[i];
    }

    var comand = input[0].match(/([\d]+)/g);
    var radius = parseInt(comand[0])%360;

    var maxLenght = 0;
    for (var i = 0; i < matrix.length; i++) {
        if (matrix[i].length > maxLenght) {
            maxLenght = matrix[i].length;
        }
    }
    var rotateMatrix = '';
    switch (radius) {
        case 0: rotateMatrix = turn0(matrix); break;
        case 90: rotateMatrix = turn90(matrix); break;
        case 180: rotateMatrix = turn180(matrix); break;
        case 270: rotateMatrix = turn270(matrix); break;
    }
    function turn0(matrix0) {
        var result = '';
        for (var row = 0; row < matrix0.length; row++) {
            for (var col = 0; col < matrix[row].length; col++) {
                result += matrix0[row][col];
            }
            result+='\n';
        }
        return result;
    }
    function turn90(matrix90) {
        var result = '';
        for (var col = 0; col < maxLenght; col++) {
            for (var row = matrix90.length - 1; row >= 0; row--) {
                if (matrix90[row][col] != undefined) {
                    result += matrix90[row][col];
                } else {
                    result += ' ';
                }
            }
            result += '\n';
        }
        return result;
    }
    function turn180(matrix180) {
        var result = '';
        for (var row = matrix180.length - 1; row >= 0; row--) {
            for (var col = maxLenght-1; col >= 0; col--) {
                if (matrix180[row][col] != undefined) {
                    result += matrix180[row][col];
                } else {
                    result += ' ';
                }
            }
            result+='\n';
        }
        return result;
    }
    function turn270(matrix270) {
        var result = '';
        for (var col = maxLenght-1; col >= 0; col--) {
            for (var row = 0; row < matrix270.length; row++) {
                if (matrix270[row][col] != undefined) {
                    result += matrix270[row][col];
                } else {
                    result += ' ';
                }
            }
            result += '\n';
        }
        return result;
    }
    return rotateMatrix;
}

solve(['Rotate(270)',
    'hello',
    'softuni',
    'exam'
])