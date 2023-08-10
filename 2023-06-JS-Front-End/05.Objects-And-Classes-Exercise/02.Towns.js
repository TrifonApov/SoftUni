function solve(inputData) {
    let cities = [];
    for (const row in inputData) {
        let currentCity = inputData[row].split(/[ |]+/);
        cities.push({
            town: currentCity[0],
            latitude: Number(currentCity[1]).toFixed(2),
            longitude: Number(currentCity[2]).toFixed(2),
        });
    }
    cities.forEach((element) => console.log(element));
}

solve(["Sofia | 42.696552 | 23.32601", "Beijing | 39.913818 | 116.363625"]);
solve(["Sofia | 42.696552 | 23.32601", "Beijing | 39.913818 | 116.363625"]);
solve(["Sofia | 42.696552 | 23.32601", "Beijing | 39.913818 | 116.363625"]);
