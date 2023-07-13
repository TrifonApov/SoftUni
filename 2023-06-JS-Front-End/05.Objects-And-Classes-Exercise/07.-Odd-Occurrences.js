function solve (input) {
    const words = input.split(' ');
    const occurrences = {};
    
    words.forEach(word => {
        if(occurrences.hasOwnProperty(word.toLowerCase())){
            occurrences[word.toLowerCase()]++;
        } else {
            occurrences[word.toLowerCase()] = 1;
        }
    });
    
    
    let odd = Object.entries(occurrences)
    .filter(word => word[1] % 2 === 1);
    let result = odd.map(word => word[0]);
    console.log(result.join(' '));
}

solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');
// solve('Cake IS SWEET is Soft CAKE sweet Food');