function solve (inputData) {
    const username = inputData[0];
    let incorrect = 0;
    for (let i = 1; i < inputData.length; i++){
        if (reverseString(username) === inputData[i]) {
            console.log(`User ${username} logged in.`);
            return;
        } else {
            incorrect++;
            if(incorrect === 4){
                console.log(`User ${username} blocked!`);
                return;
            }
            console.log(`Incorrect password. Try again.`);
        }
    }
    function reverseString(str) {
        return (str === '') ? '' : reverseString(str.substr(1)) + str.charAt(0);
    }
}


solve(['Acer','login','go','let me in','recA']);
solve(['momo','omom']);
solve(['sunny','rainy','cloudy','sunny','not sunny']);

