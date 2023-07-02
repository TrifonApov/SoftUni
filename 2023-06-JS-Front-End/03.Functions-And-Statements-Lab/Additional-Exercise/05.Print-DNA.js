function solve (n) {
    let starCount = 2;
    let dashCount = 0;
    let letters = 'ATCGTTAGGG'.split('');
    let growing = true;

    for (let i = 0; i < n; i++){
        
        console.log(`${'*'.repeat(starCount)}${letters[0]}${'-'.repeat(dashCount)}${letters[1]}${'*'.repeat(starCount)}`);
        letters.push(letters.shift());
        letters.push(letters.shift());
        
        if (growing) {
            starCount--;
            dashCount+=2;
            if(starCount == 0) {
                growing = false;
            }
        } else {
            starCount++;
            dashCount-=2;
            if(starCount == 2) {
                growing = true;
            }
        }
    }

}


solve(10);