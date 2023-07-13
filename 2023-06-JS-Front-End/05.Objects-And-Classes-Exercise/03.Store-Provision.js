function solve (storeInput, orderInput) {
    let store = {};

    for (let i = 0; i < storeInput.length; i+=2){
        store[storeInput[i]] = Number(storeInput[i+1]);
    }
    
    for (let i = 0; i < orderInput.length; i+=2){
        if(store.hasOwnProperty(orderInput[i])){
            store[orderInput[i]] += Number(orderInput[i+1]);
        } else {
            store[orderInput[i]] = Number(orderInput[i+1]);        
        }
    }

    Object.entries(store).forEach((product) => console.log(`${product[0]} -> ${product[1]}`))
}


solve(
    ['Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'],
    ['Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30']
);