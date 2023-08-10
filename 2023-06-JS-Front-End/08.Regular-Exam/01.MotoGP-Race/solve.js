function solve (commands) {
    const ridersCount = commands.shift();
    const ridersInput = commands.splice(0,ridersCount);
    const riders = {};

    ridersInput.forEach(input => {
        let [riderName, fuelCapacity, position] = input.split('|');
        fuelCapacity = Number(fuelCapacity);
        position = Number(position);
        riders[riderName] = {fuelCapacity,position};
    });
    
    commands.forEach(command => {
        const commandInfo = command.split(' - ');

        switch (commandInfo[0]){
            case 'StopForFuel': 
                if (riders[commandInfo[1]].fuelCapacity < Number(commandInfo[2])) {
                    riders[commandInfo[1]].position = Number(commandInfo[3]);
                    riders[commandInfo[1]].fuel = Number(commandInfo[2]);
                    
                    console.log(`${commandInfo[1]} stopped to refuel but lost his position, now he is ${commandInfo[3]}.`);
                } else {
                    console.log(`${commandInfo[1]} does not need to stop for fuel!`);
                }
            break;
            case 'Overtaking':
                const rider1Name = commandInfo[1];
                const rider2Name = commandInfo[2];
                if (riders[rider1Name].position < riders[rider2Name].position) {
                    
                    let rider1oldPos = riders[rider1Name].position;
                    let rider2oldPos = riders[rider2Name].position;
                    riders[rider2Name].position = rider1oldPos;
                    riders[rider1Name].position = rider2oldPos;
                    
                    console.log(`${rider1Name} overtook ${rider2Name}!`);
                }
                break;
            case 'EngineFail': 
            const riderName = commandInfo[1];
            const lapsLeft = commandInfo[2];
                delete riders[riderName];
                console.log(`${riderName} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`);
            break;
            case 'finish': break;
        }
    })

    const entries = Object.entries(riders);
    entries.sort((a, b) => a[1].position - b[1].position);
    const sortedData = Array.from(entries);

    sortedData.forEach(function (rider, i) {
        console.log(rider[0]);
        console.log(`  Final position: ${rider[1].position}`);
    });
}


solve([
    "3",
    "Valentino Rossi|100|1",
    "Marc Marquez|90|2",
    "Jorge Lorenzo|80|3",
    "StopForFuel - Valentino Rossi - 50 - 1",
    "Overtaking - Marc Marquez - Jorge Lorenzo",
    "EngineFail - Marc Marquez - 10",
    "Finish"
]);

solve([
    "4",
    "Valentino Rossi|100|1",
    "Marc Marquez|90|3",
    "Jorge Lorenzo|80|4",
    "Johann Zarco|80|2",
    "StopForFuel - Johann Zarco - 90 - 5",
    "Overtaking - Marc Marquez - Jorge Lorenzo",
    "EngineFail - Marc Marquez - 10",
    "Finish"
]);
