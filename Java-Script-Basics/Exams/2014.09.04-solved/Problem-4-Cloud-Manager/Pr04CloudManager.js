function solve(input) {
    var allData = [];
    var extensions = {};
    for (var i = 0; i < input.length; i++) {
       allData[i] = input[i].split(/\s/);
    }
    for (var i = 0; i < allData.length; i++) {
        allData[i][2] = allData[i][2].slice(0, allData[i][2].length-2);
    }
    for (var i = 0; i < allData.length; i++) {
        if (!extensions.hasOwnProperty(allData[i][1])) {
            extensions[allData[i][1]] = {
                files : [allData[i][0]],
                memory : parseFloat(allData[i][2])
            }
        } else {
            var currFile = extensions[allData[i][1]].files;
            var currMemory = extensions[allData[i][1]].memory;
            currFile.push(allData[i][0]);
            currMemory += parseFloat(allData[i][2]);
            extensions[allData[i][1]] = {
                files : currFile,
                memory : currMemory
            }
        }

    }
    var sortedObj = {};
    var keys = [];
    var k, j, len;
    for (k in extensions) {
        if (extensions.hasOwnProperty(k))
        {
            keys.push(k);
        }
    }
    keys.sort();

    len = keys.length;

    for (j = 0; j < len; j++)
    {
        k = keys[j];
        sortedObj[k] = extensions[k];
    }
    for (var obj in sortedObj) {
        var sortedFiles = [];
        sortedFiles = sortedObj[obj].files;
        sortedFiles = sortedFiles.sort();
        sortedObj[obj].files = sortedFiles;

        sortedObj[obj].memory = sortedObj[obj].memory.toFixed(2);
    }
    return JSON.stringify(sortedObj);
}

solve(['sentinel .exe 15MB',
    'zoomIt .msi 3MB',
    'skype .exe 45MB',
    'trojanStopper .bat 23MB',
    'kindleInstaller .exe 120MB',
    'setup .msi 33.4MB',
    'winBlock .bat 1MB'])