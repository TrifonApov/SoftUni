function solve (lostFights, helmetPrice, swordPrice, shieldPrice, armorPrice) {
    let helmetLost = Math.floor(lostFights / 2);
    let swordLost = Math.floor(lostFights / 3);
    let shieldLost = Math.floor(lostFights / 6);
    let armorLost = Math.floor(lostFights / 12);

    let sum = helmetLost*helmetPrice + swordLost*swordPrice + shieldLost*shieldPrice + armorLost*armorPrice
    
    console.log(`Gladiator expenses: ${sum.toFixed(2)} aureus`);
}


solve(7, 2, 3, 4, 5);
solve(23, 12.50, 21.50, 40, 200);