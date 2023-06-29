function solve (product, count) {
    let priceForProduct = getPriceForProduct(product)
    console.log((priceForProduct * count).toFixed(2));

    function getPriceForProduct(product) {
        switch (product) {
            case 'coffee': return 1.5;
            case 'water': return 1.0;
            case 'coke': return 1.4;
            case 'snacks': return 2;
        }
    }
}

solve('water', 5);
solve('coffee', 2);