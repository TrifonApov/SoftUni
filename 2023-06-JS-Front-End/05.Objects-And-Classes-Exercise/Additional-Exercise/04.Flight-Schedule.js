function solve (input) {
    class Flight {
        constructor(flightNumber, destination) {
            this.flightNumber = flightNumber;
            this.destination = destination;
            this.isReadyToFly = 'Ready to fly';
        }

        print() {
            return `{ Destination: '${this.destination}', Status: '${this.isReadyToFly}' }`;
        }
    }   

    const flights = [];

    input[0].forEach(flightInfo => {
        const [flightNumber, destination] = flightInfo.split(' ');
        flights.push(new Flight(flightNumber, destination));

    });


    input[1].forEach(changeStatusInfo => {
        const number = changeStatusInfo.split(' ')[0];
        let indexToCancel = flights.findIndex(flight => flight.flightNumber === number);
        if (indexToCancel >= 0) { 
            flights[indexToCancel].isReadyToFly = 'Cancelled';
        };
    });

    

    flights
        .filter(flight => flight.isReadyToFly === input[2][0])
        .forEach(flight => {
        console.log(flight.print())
    });
}


solve([
    [
        'WN269 Delaware',
        'FL2269 Oregon',
        'WN498 Las Vegas',
        'WN3145 Ohio',
        'WN612 Alabama',
        'WN4010 New York',
        'WN1173 California',
        'DL2120 Texas',
        'KL5744 Illinois',
        'WN678 Pennsylvania'
    ],
    [
        'DL2120 Cancelled',
        'WN612 Cancelled',
        'WN1173 Cancelled',
        'SK430 Cancelled'
    ],
    [
        'Cancelled'
    ]
]);

// solve([
//     [
//         'WN269 Delaware',
//         'FL2269 Oregon',
//         'WN498 Las Vegas',
//         'WN3145 Ohio',
//         'WN612 Alabama',
//         'WN4010 New York',
//         'WN1173 California',
//         'DL2120 Texas',
//         'KL5744 Illinois',
//         'WN678 Pennsylvania'
//     ],
//     [
//         'DL2120 Cancelled',
//         'WN612 Cancelled',
//         'WN1173 Cancelled',
//         'SK330 Cancelled'
//     ],
//     [
//         'Ready to fly'
//     ]
// ]);