function solve(input) {
    let rows = Number(input.shift());

    let piecesMap = {};

    // Add to map
    for (let index = 0; index < rows; index++) {
        let [ piece, composer, key ] = input.shift().split('|');
        
        piecesMap[piece] = { composer, key };
    }

    // Parse commands
    input.forEach(line => {
        let tokens = line.split('|');
        let command = tokens.shift();

        if (command === 'Add') {
            let [ piece, composer, key ] = tokens;

            if (!piecesMap.hasOwnProperty(piece)) {
                piecesMap[piece] = { composer, key };
                console.log(`${piece} by ${composer} in ${key} added to the collection!`);
            } else {
                console.log(`${piece} is already in the collection!`);
            }
        } else if (command === 'Remove') {
            let piece = tokens.shift();

            if (!piecesMap.hasOwnProperty(piece)) {
                console.log(`Invalid operation! ${piece} does not exist in the collection.`);
            } else {
                delete piecesMap[piece];
                console.log(`Successfully removed ${piece}!`);
            }
        } else if (command === 'ChangeKey') {
            let [ piece, newKey ] = tokens;

            if (!piecesMap.hasOwnProperty(piece)) {
                console.log(`Invalid operation! ${piece} does not exist in the collection.`);
            } else {
                piecesMap[piece].key = newKey;
                console.log(`Changed the key of ${piece} to ${newKey}!`);
            }
        }
    });

    let entries = Object.entries(piecesMap);

    for (const [ piece, info ] of entries) {
        console.log(`${piece} -> Composer: ${info.composer}, Key: ${info.key}`);
    }
}