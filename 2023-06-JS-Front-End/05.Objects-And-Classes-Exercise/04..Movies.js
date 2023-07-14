function solve (commands) {
    let movies = [];

    for (const command of commands) {
        if (command.includes('addMovie')) {
            let splitedCommand = command.split(' ');
            splitedCommand.shift();
            let name = splitedCommand.join(' ');
            movies.push({
                name: name
            });
        } else if (command.includes('directedBy')) {
            let splitedCommand = command.split(' directedBy ');
            const result = movies.find(({ name }) => name === splitedCommand[0]);
            if (result !== undefined) {
                result['director'] = splitedCommand[1];
            }
            console.log();
        } else {
            let splitedCommand = command.split(' onDate ');
            const result = movies.find(({ name }) => name === splitedCommand[0]);
            if (result !== undefined) {
                result['date'] = splitedCommand[1];
            }
        }
    }
    movies.forEach(movie => {
        if (Object.keys(movie).length === 3) {
            console.log(JSON.stringify(movie))}
        });
}


// solve([
//     'addMovie Fast and Furious',
//     'addMovie Godfather',
//     'Inception directedBy Christopher Nolan',
//     'Godfather directedBy Francis Ford Coppola',
//     'Godfather onDate 29.07.2018',
//     'Fast and Furious onDate 30.07.2018',
//     'Batman onDate 01.08.2018',
//     'Fast and Furious directedBy Rob Cohen'
// ]);

solve([
    'addMovie The Avengers',
    'addMovie Superman',
    'The Avengers directedBy Anthony Russo',
    'The Avengers onDate 30.07.2010',
    'Captain America onDate 30.07.2010',
    'Captain America directedBy Joe Russo'
]);