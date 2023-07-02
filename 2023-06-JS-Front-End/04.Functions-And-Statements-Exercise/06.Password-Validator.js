function solve (password) {
    let isPassValid = true;
    if (password.length < 6 || password.length > 10) {
        console.log('Password must be between 6 and 10 characters');
        isPassValid = false;
    }

    const regex = /[^A-Za-z0-9]/g;
    const found = password.match(regex);
    if (found !== null) {
        console.log('Password must consist only of letters and digits');
        isPassValid = false;
    }

    let digitCount = 0;
    for (const ch of password) {
        let a = typeof(ch);
        if(!isNaN(ch)){
            digitCount++;
        }
        if (digitCount > 1) {
            break;
        }
    }
    if (digitCount < 2) {
        console.log('Password must have at least 2 digits');
        isPassValid = false;
    }

    if (isPassValid) {
        console.log('Password is valid');
    }
}


solve('logIn');
solve('MyPass123');
solve('Pa$s$s');