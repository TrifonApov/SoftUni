// Cut – cuts the crystal in 4
// Lap – removes 20% of the crystal’s thickness
// Grind – removes 20 microns of thickness
// Etch – removes 2 microns of thickness
// X-ray – increases the thickness of the crystal by 1 micron; this operation can only be done once!
// Transporting and washing – removes any imperfections smaller than 1 micron (round down the number); do this after every batch of operations that remove material

function solve (inputParameters) {
    
    const operations = {
        'Cut': (x) => x / 4,
        'Lap': (x) => x * 0.8,
        'Grind': (x) => x - 20,
        'Etch': (x) => x - 2,
        'X-ray': (x) => x + 1,
        'Transporting and washing': (x) => {
            console.log(`Transporting and washing`);
            return Math.floor(x);
        }
    }

    const desiredThickness = inputParameters.shift();
    const crystals = inputParameters.slice();
    
    
    for (let crystal of crystals) {
        let cuts = 0;
        let laps = 0;
        let grinds = 0;
        let etchs = 0;
        let xRays = 0;
        console.log(`Processing chunk ${crystal} microns`);
        
        //CUT
        while (operations['Cut'](crystal) >= desiredThickness) {
            crystal = operations['Cut'](crystal);
            cuts++;
        }
        
        if (cuts > 0) {
            console.log(`Cut x${cuts}`);
            crystal = operations['Transporting and washing'](crystal);
        }
        
        if (crystal === desiredThickness) {
            console.log(`Finished crystal ${desiredThickness} microns`);
            continue;
        }
        
        // LAP
        while (operations['Lap'](crystal) >= desiredThickness) {
            crystal = operations['Lap'](crystal);
            laps++;
        }
        
        if (laps > 0) {
            console.log(`Lap x${laps}`);
            crystal = operations['Transporting and washing'](crystal);
        }
        
        if (crystal === desiredThickness) {
            console.log(`Finished crystal ${desiredThickness} microns`);
            continue;
        }

        // GRIND
        while (operations['Grind'](crystal) >= desiredThickness) {
            crystal = operations['Grind'](crystal);
            grinds++;
        }
        
        if (grinds > 0) {
            console.log(`Grind x${grinds}`);
            crystal = operations['Transporting and washing'](crystal);
        }
        
        if (crystal === desiredThickness) {
            console.log(`Finished crystal ${desiredThickness} microns`);
            continue;
        }
        
        // ETCH
        while (crystal > desiredThickness) {
            crystal = operations['Etch'](crystal);
            etchs++;
            if (crystal === desiredThickness - 1 || crystal === desiredThickness){
                break;
            }
        }
        
        if (etchs > 0) {
            console.log(`Etch x${etchs}`);
            crystal = operations['Transporting and washing'](crystal);
        }
        
        if (crystal === desiredThickness) {
            console.log(`Finished crystal ${desiredThickness} microns`);
            continue;
        }

        if (crystal < desiredThickness) {
            crystal = operations['X-ray'](crystal);
            xRays++;
            console.log(`X-ray x${xRays}`);
        }
        console.log(`Finished crystal ${desiredThickness} microns`);
    }
}


// solve([1375, 50000]);
// console.log('----------------------');
solve([10001, 10000]);

// let a = 1002 !== 999;
// let b = 1002 !== 1000;

// while (a && b) {
//     console.log('a');
// }