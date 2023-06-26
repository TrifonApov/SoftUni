function solve (x1,y1,x2,y2) {
    let distanceBetweenPoints = Math.sqrt(Math.pow(x2-x1,2) + Math.pow(y2-y1,2));
    let distanceFromZeroPoint1 = Math.sqrt(Math.pow(0-x1,2) + Math.pow(0-y1,2));
    let distanceFromZeroPoint2 = Math.sqrt(Math.pow(x2-0,2) + Math.pow(y2-0,2));
    
    
    console.log(Number.isInteger(distanceFromZeroPoint1) ? `{${x1}, ${y1}} to {0, 0} is valid` : `{${x1}, ${y1}} to {0, 0} is invalid`);
    console.log(Number.isInteger(distanceFromZeroPoint2) ? `{${x2}, ${y2}} to {0, 0} is valid` : `{${x2}, ${y2}} to {0, 0} is invalid`);
    console.log(Number.isInteger(distanceBetweenPoints) ? `{${x1}, ${y1}} to {${x2}, ${y2}} is valid` : `{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
}


solve(3, 0, 0, 4);
solve(2, 1, 1, 1);