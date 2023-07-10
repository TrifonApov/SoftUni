function solve (inputData) {
    let employees = {};
    for (const currentEntry of inputData) {
        employees[currentEntry] = currentEntry.length;
    }
    
    for (const [employeeName, personalNum] of Object.entries(employees)) {
        console.log(`Name: ${employeeName} -- Personal Number: ${personalNum}`);
    }
}

solve(['Silas Butler','Adnaan Buckley','Juan Peterson','Brendan Villarreal']);