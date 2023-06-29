function solve (startingYield) {
    let yieldCount = 0;
    let days = 0;
    let workersConsumption = 26;

    while (startingYield >= 100) {
        days++;
        yieldCount+= startingYield-workersConsumption;
        
        startingYield-=10;
    }

    yieldCount-=workersConsumption;
    if (yieldCount <= 0) {
        yieldCount = 0;
    }
    console.log(days);
    console.log(yieldCount);
}

solve(0);
solve(450);