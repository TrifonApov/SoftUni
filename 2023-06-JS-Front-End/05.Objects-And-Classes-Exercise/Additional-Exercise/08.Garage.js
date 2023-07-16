function solve (input) {
    const garages = {};
    input.forEach(line => {
        const [garageNumber, carInfo] = line.split(' - ');
        if(!garages[garageNumber]) {
            garages[garageNumber] = [];
        }
        const car = {};
        carInfo.split(', ').forEach(element => {
            const [key, value] = element.split(': ');
            car[key] = value;
            
        });
        garages[garageNumber].push(car);
    });    

    const sortKeys = Object.keys(garages).sort();
    sortKeys.forEach(garage => {
        console.log(`Garage № ${garage}`);
        garages[garage].forEach(car => {
            let result = [];
            Object.keys(car).forEach(carProperty => {
                result.push(`${carProperty} - ${car[carProperty]}`);
            })
            console.log(`--- ${result.join(', ')}`);
        })
    })


    //console.log(JSON.stringify(garages, null, 3));
}


solve([
    '1 - color: blue, fuel type: diesel', 
    '1 - color: red, manufacture: Audi', 
    '2 - fuel type: petrol', 
    '4 - color: dark blue, fuel type: diesel, manufacture: Fiat'
]);

solve([
    '1 - color: green, fuel type: petrol',
    '1 - color: dark red, manufacture: WV',
    '2 - fuel type: diesel',
    '3 - color: dark blue, fuel type: petrol'
]);