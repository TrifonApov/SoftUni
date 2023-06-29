function solve (string, times) {
    console.log(repeatString(string,times));

    function repeatString(string, times) {
        let result = "";
        for (let i = 0; i < times; i++) {
            result+=string;
        }
        return result;
    }
}




solve ('abc',3);
solve ('String',3);