function solve (input) {
    const dictionary = input.reduce(
        (acc, currentTerm) => {
            let term = Object.entries(JSON.parse(currentTerm));
            acc[term[0][0]] = term[0][1];
            return acc;
        }, {})
    
    const ordered = Object.keys(dictionary).sort().reduce(
        (obj, key) => { 
            obj[key] = dictionary[key]; 
            return obj;
        }, {});

    Object.entries(ordered).forEach(term =>{
        console.log(`Term: ${term[0]} => Definition: ${term[1]}`);
    });
}


solve(['{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
    '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
    '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
    '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
    '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}']);

