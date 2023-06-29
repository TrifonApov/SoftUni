function solve (base, increment) {
    let stone = 0;
    let marble = 0;
    let lapisLazuli = 0;
    let gold = 0;
    let stepCount = 1;

    while (base > 2){

        let luxuryForStep = (base * 4 - 4)*increment
        if (stepCount % 5 === 0) {
            lapisLazuli += luxuryForStep;
        } else {
            marble += luxuryForStep;
        }
        
        base-=2;
        let stoneForStep = base*base*increment;
        if (base > 1){
            stone += stoneForStep;
        } else {
            stone+=increment;
        }

        stepCount++;
    }
    gold+=base*base*increment;
    console.log(`Stone required: ${Math.ceil(stone)}`);
    console.log(`Marble required: ${Math.ceil(marble)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapisLazuli)}`);
    console.log(`Gold required: ${Math.ceil(gold)}`);
    console.log(`Final pyramid height: ${Math.floor(stepCount*increment)}`);
}

for (let i = 0; i<10; i++){
    console.log(i);
         console.log(i+1000);
}
// solve(11,1);
// console.log('-----------');
// solve(11,0.75);
// console.log('-----------');
// solve(12,1);
// console.log('-----------');
// solve(23,0.5);