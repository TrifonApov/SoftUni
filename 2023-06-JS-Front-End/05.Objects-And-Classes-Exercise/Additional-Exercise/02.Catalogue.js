function solve (input) {

    const products = input.reduce((acc, curr) => {
        const [product, price]= curr.split(' : ');
        if (!acc[product[0]]) {
            acc[product[0]] = [];
        }

        acc[product[0]].push({ product, price});
        return acc;
    }, {});

    Object.keys(products)
        .sort()
        .forEach(letter => {
            console.log(letter);
            products[letter]
                .sort((a, b) => a.product.localeCompare(b.product))
                .forEach(product => {
                    console.log(`  ${product.product}: ${product.price}`);
                });
        })
    
}

solve([
    'Az : 20.4',
    'Aidge : 15',
    'AV : 99',
    'Neod : 5',
    'Loiler : 74',
    'KSpray : 15',
    'Shirt : 49',
    'ZA : 32.12',
    'XAxs : 43',
    'DA : 21'
]);
// solve([
//     'Appricot : 20.4',
//     'Fridge : 1500',
//     'TV : 1499',
//     'Deodorant : 10',
//     'Boiler : 300',
//     'Apple : 1.25',
//     'Anti-Bug Spray : 15',
//     'T-Shirt : 10'
// ]);