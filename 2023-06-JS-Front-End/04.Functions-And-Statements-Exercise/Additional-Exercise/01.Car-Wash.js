function solve (inputArray) {
    let car = 0;
    const commands = {
        'soap': (x) => x+=10,
        'water': (x) => x*=1.2,
        'vacuum cleaner': (x) => x*=1.25,
        'mud': (x) => x*=0.9
    }

    for (const command of inputArray) {
        car = commands[command](car);
    }
    console.log(`The car is ${car.toFixed(2)}% clean.`);
}


solve(['soap', 'soap', 'vacuum cleaner', 'mud', 'soap', 'water']);
solve(["soap", "water", "mud", "mud", "water", "mud", "vacuum cleaner"]);