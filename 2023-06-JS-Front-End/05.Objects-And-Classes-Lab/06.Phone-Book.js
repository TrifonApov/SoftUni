function solve (inputData) {
    let phoneBook = {};
    
    for (let index in inputData) {
        let splitedInfo = inputData[index].split(' ');
        phoneBook[splitedInfo[0]] = splitedInfo[1];
    }

    Object.entries(phoneBook).forEach((key, value) =>{
        console.log(`${key} -> ${value}`);
    });
}

solve(
    ['Tim 0834212554',
    'Peter 0877547887',
    'Bill 0896543112',
    'Tim 0876566344']);

solve(
    ['George 0552554',
    'Peter 087587',
    'George 0453112',
    'Bill 0845344']);