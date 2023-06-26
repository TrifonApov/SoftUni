function solve (days) {
    const goldPricePerGram = 67.51;
    const bitcoinPrice = 11949.16;
    
    let bitcoinCount = 0;
    let firstDay = 0;
    let totalMoney = 0;

    for (let i = 0; i < days.length; i++){
        if ((i+1) % 3 === 0 && i > 1) {
            days[i] *= 0.7;
        }
        
        totalMoney += days[i]*goldPricePerGram;
        
        if (totalMoney >= bitcoinPrice) {
            if(bitcoinCount === 0){
                firstDay = i+1;
            }
            bitcoinCount += Math.floor(totalMoney / bitcoinPrice);
            totalMoney -= Math.floor(totalMoney / bitcoinPrice) * bitcoinPrice;
        }
    }
    console.log(`Bought bitcoins: ${bitcoinCount}`);
    if (firstDay > 0) {
        console.log(`Day of the first purchased bitcoin: ${firstDay}`);
    }
    console.log(`Left money: ${totalMoney.toFixed(2)} lv.`);

}


solve([100, 200, 300]);
solve([50, 100] );
solve([3124.15, 504.212, 2511.124]);