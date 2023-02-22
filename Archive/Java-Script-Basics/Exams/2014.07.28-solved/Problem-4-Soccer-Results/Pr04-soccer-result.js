function solve(input) {
    var allData = [];

    for (var i = 0; i < input.length; i++) {
        allData[i] = input[i].match(/([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+)|(\d+)|(\d+)/igm);
    }

    var res = {};


    //fill main object
    for (i = 0; i < allData.length; i++) {
        //home
        if (!res.hasOwnProperty(allData[i][0])) {
            res[allData[i][0]] = {
                goalsScored: parseInt(allData[i][2]),
                goalsConceded: parseInt(allData[i][3]),
                matchesPlayedWith: [allData[i][1]]
            };
        }
        else {
            var currScored = res[allData[i][0]].goalsScored;
            currScored += parseInt(allData[i][2]);
            var currConceded = res[allData[i][0]].goalsConceded;
            currConceded += parseInt(allData[i][3]);
            var currPlayedWith = res[allData[i][0]].matchesPlayedWith;
            currPlayedWith.push(allData[i][1]);
            res[allData[i][0]] = {
                goalsScored: currScored,
                goalsConceded: currConceded,
                matchesPlayedWith: currPlayedWith
            }
        }

        //guest
        if (!res.hasOwnProperty(allData[i][1])) {
            res[allData[i][1]] = {
                goalsScored: parseInt(allData[i][3]),
                goalsConceded: parseInt(allData[i][2]),
                matchesPlayedWith: [allData[i][0]]
            };
        }
        else {
            var currScored = res[allData[i][1]].goalsScored;
            currScored += parseInt(allData[i][3]);
            var currConceded = res[allData[i][1]].goalsConceded;
            currConceded += parseInt(allData[i][2]);
            var currPlayedWith = res[allData[i][1]].matchesPlayedWith;
            currPlayedWith.push(allData[i][0]);
            res[allData[i][1]] = {
                goalsScored: currScored,
                goalsConceded: currConceded,
                matchesPlayedWith: currPlayedWith
            }
        }
    }
    //fill the object end

    //sort the object
    var sortedObj = {};
    var keys = [];
    var k, j, len;
    for (k in res) {
        if (res.hasOwnProperty(k))
        {
            keys.push(k);
        }
    }
    keys.sort();

    len = keys.length;

    for (j = 0; j < len; j++)
    {
        k = keys[j];
        sortedObj[k] = res[k];
    }
    //end sort the object

    //sort array in object
    for (var obj in sortedObj) {
        var playedWithArr = [];
        playedWithArr = sortedObj[obj].matchesPlayedWith;
        playedWithArr = playedWithArr.sort();
        sortedObj[obj].matchesPlayedWith = playedWithArr;
    }
    //remove repeated in matchersPlayedWith
    for (var obj in sortedObj) {
        var playedWithArr = [];
        playedWithArr = sortedObj[obj].matchesPlayedWith;
        playedWithArr = playedWithArr.filter(function (a,b) {
            return playedWithArr.indexOf(a) == b;
        });
        sortedObj[obj].matchesPlayedWith = playedWithArr;
    }
    var result = JSON.stringify(sortedObj);
    console.log(result);
    return result;

}

solve(['Levski / CSKA: 0-2',
    'Pavlikeni / Loko Gorna: 4-2',
    'Loko Gorna / Levski: 1-4',
    'Litex / Loko Gorna: 0-0',
    'Beroe / Botev Plovdiv: 2-1',
    'Loko Gorna / Beroe: 3-1',
    'Pavlikeni / Ludogorets: 0-2',
    'Loko Sofia / Litex: 0-2',
    'Pavlikeni / Marek: 1-1',
    'Litex / Levski: 0-0',
    'Beroe / Litex: 3-2',
    'Litex / Beroe: 1-0',
    'Ludogorets / Litex: 3-0',
    'Litex / Ludogorets: 1-0',
    'CSKA / Beroe: 1-0',
    'Botev Plovdiv / CSKA: 1-1',
    'Ludogorets / Loko Sofia: 1-0',
    'Litex / CSKA: 0-1',
    'Marek / Haskovo: 0-1',
    'Levski / Loko Gorna: 1-1'
]);