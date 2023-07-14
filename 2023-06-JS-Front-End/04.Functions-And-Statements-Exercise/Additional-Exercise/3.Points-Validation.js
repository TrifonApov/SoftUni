function solve (coordinates) {
    let distanceBetweenPoints = Math.sqrt(Math.pow(coordinates[2]-coordinates[0],2) + Math.pow(coordinates[3]-coordinates[1],2));
    let distanceFromZeroPoint1 = Math.sqrt(Math.pow(0-coordinates[0],2) + Math.pow(0-coordinates[1],2));
    let distanceFromZeroPoint2 = Math.sqrt(Math.pow(coordinates[2]-0,2) + Math.pow(coordinates[3]-0,2));
    
    
    console.log(Number.isInteger(distanceFromZeroPoint1) ? `{${coordinates[0]}, ${coordinates[1]}} to {0, 0} is valid` : `{${coordinates[0]}, ${coordinates[1]}} to {0, 0} is invalid`);
    console.log(Number.isInteger(distanceFromZeroPoint2) ? `{${coordinates[2]}, ${coordinates[3]}} to {0, 0} is valid` : `{${coordinates[2]}, ${coordinates[3]}} to {0, 0} is invalid`);
    console.log(Number.isInteger(distanceBetweenPoints) ? `{${coordinates[0]}, ${coordinates[1]}} to {${coordinates[2]}, ${coordinates[3]}} is valid` : `{${coordinates[0]}, ${coordinates[1]}} to {${coordinates[2]}, ${coordinates[3]}} is invalid`);
}


solve([3, 0, 0, 4]);
solve([2, 1, 1, 1]);