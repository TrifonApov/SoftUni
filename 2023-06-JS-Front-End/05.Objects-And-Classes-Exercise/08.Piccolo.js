function solve (input) {
    let parking = [];

    input.forEach(command => {
        [direction, car] = command.split(', ');
        
        if(direction === 'IN' && parking.indexOf(car) === -1){
            parking.push(car);
        } else if(direction === 'OUT' && parking.indexOf(car) >= 0){
            const index = parking.indexOf(car);
            parking.splice(index, 1);
        }
    });
    console.log(parking.length === 0 ? 'Parking Lot is Empty' : parking.sort().join('\n'));
}

// solve(['IN, CA2844AA',
// 'IN, CA1234TA',
// 'OUT, CA2844AA',
// 'IN, CA9999TT',
// 'IN, CA2866HI',
// 'OUT, CA1234TA',
// 'IN, CA2844AA',
// 'OUT, CA2866HI',
// 'IN, CA9876HH',
// 'IN, CA2822UU']);
// console.log('-------------------------------');
// solve(['IN, CA2844AA',
// 'IN, CA1234TA',
// 'OUT, CA2844AA',
// 'OUT, CA1234TA']);