function solve (fruit, grams, pricePerKg) {
    let weight = grams / 1000;
    let totalPrice = weight * pricePerKg;

    console.log(`I need $${totalPrice.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`);
}


solve('orange', 2500, 1.80 );
solve('apple', 1563, 2.35 );
