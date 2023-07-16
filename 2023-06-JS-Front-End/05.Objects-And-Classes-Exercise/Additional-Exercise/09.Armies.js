function solve (input) {
    const leaders = {};
    input.forEach(command => {
        if (command.includes('arrives')) {
            const leaderName = command.substring(0, command.indexOf(' arrives'));
            // if(!leaders.hasOwnProperty(leaderName)) {
                leaders[leaderName] = {};
            // }
        } else if (command.includes(': ')){
            const [leaderName, newArmyInfo] = command.split(': ');
            if (leaders.hasOwnProperty(leaderName)) {
                // leaders[leaderName] = {};
                const [armyName, count] = newArmyInfo.split(', ');
                leaders[leaderName][armyName] = Number(count);
            }
        } else if (command.includes('+')) {
            const [armyName, count] = command.split(' + ');
            for (const leader in leaders) {
                if (leaders[leader].hasOwnProperty(armyName)) {
                    leaders[leader][armyName] += Number(count);
                }
            }
        } else if (command.includes('defeated')) {
            const leaderName = command.substring(0, command.indexOf(' defeated'));
            delete leaders[leaderName];
        }
    });

    function sortObjectByNestedSum(obj) {
        // Calculate the sum of nested values for each key
        const sums = Object.entries(obj).map(([key, nestedObj]) => {
          const sum = Object.values(nestedObj).reduce((acc, val) => acc + val, 0);
          return { key, sum };
        });
      
        // Sort the keys based on the calculated sums in descending order
        sums.sort((a, b) => b.sum - a.sum);
      
        // Reconstruct the object using the sorted keys
        const sortedObj = {};
        sums.forEach(({ key }) => {
          sortedObj[key] = obj[key];
        });
      
        return sortedObj;
      }

    const result = sortObjectByNestedSum(leaders);

    Object.keys(result).forEach(leader => {
        const totalArmyCount = Object.entries(leaders[leader]).reduce((acc, curr)=>{
            return acc+curr[1];
        },0)
        console.log(`${leader}: ${totalArmyCount}`);

        
        Object.entries(leaders[leader])
            .sort((a, b) => b[1] - a[1])
            .forEach(entry => {
                console.log(`>>> ${entry[0]} - ${entry[1]}`);
            });
    })
    
}


// solve([
// 	'Rick Burr arrives', 
// 	'Fergus: Wexamp, 30245',
// 	'Rick Burr: Juard, 50000',
// 	'Findlay arrives',
// 	'Findlay: Britox, 34540',
// 	'Wexamp + 6000',
// 	'Juard + 1350',
// 	'Britox + 4500',
// 	'Porter arrives',
// 	'Porter: Legion, 55000',
// 	'Legion + 302',
// 	'Rick Burr defeated',
// 	'Porter: Retix, 3205'
// ]);

solve([
    'Rick Burr arrives', 
    'Findlay arrives',
    'Rick Burr: Juard, 1500',
    'Wexamp arrives',
    'Findlay: Wexamp, 34540',
    'Wexamp + 340', 
    'Wexamp: Britox, 1155',
    'Wexamp: Juard, 43423'
]);