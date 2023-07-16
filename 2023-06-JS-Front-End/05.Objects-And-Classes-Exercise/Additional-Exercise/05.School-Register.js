function solve (input) {
    const grades = {};
    input.forEach(row => {
        const splitedRow = row.split(', ');
        const studentName = splitedRow[0].split(': ')[1];
        const grade = Number(splitedRow[1].split(': ')[1]);
        const avgScore = Number(splitedRow[2].split(': ')[1]);

        if(!grades[Number(grade)]){
            grades[Number(grade)] = {};
        }

        if(avgScore >= 3.00){
            grades[grade][studentName] = avgScore;
        }
    });

    const orderedKeys = Object.keys(grades)
    .map(Number)
    .sort((a, b) => a - b);

    orderedKeys.forEach(grade => {
        const nextGrade = grade + 1;
        const students = Object.keys(grades[grade]).join(', ');
        const studentsCount = Object.keys(grades[grade]).length;
        if(studentsCount){
            const avgerageGrade = Object.values(grades[grade])
                .reduce((acc, curr)=>{
                    acc+=curr;
                    return acc;
                },0) / studentsCount;
            
            console.log(`${nextGrade} Grade`);
            console.log(`List of students: ${students}`);
            console.log(`Average annual score from last year: ${avgerageGrade.toFixed(2)}`);
            console.log('');
        }
    })
}


// solve([
//     "Student name: Mark, Grade: 8, Graduated with an average score: 4.75",
//     "Student name: Ethan, Grade: 9, Graduated with an average score: 5.66",
//     "Student name: George, Grade: 8, Graduated with an average score: 2.83",
//     "Student name: Steven, Grade: 10, Graduated with an average score: 4.20",
//     "Student name: Joey, Grade: 9, Graduated with an average score: 4.90",
//     "Student name: Angus, Grade: 11, Graduated with an average score: 2.90",
//     "Student name: Bob, Grade: 11, Graduated with an average score: 5.15",
//     "Student name: Daryl, Grade: 8, Graduated with an average score: 5.95",
//     "Student name: Bill, Grade: 9, Graduated with an average score: 6.00",
//     "Student name: Philip, Grade: 10, Graduated with an average score: 5.05",
//     "Student name: Peter, Grade: 11, Graduated with an average score: 4.88",
//     "Student name: Gavin, Grade: 10, Graduated with an average score: 4.00"
// ]);

solve([
    'Student name: George, Grade: 5, Graduated with an average score: 2.75',
    'Student name: Alex, Grade: 9, Graduated with an average score: 3.66',
    'Student name: Peter, Grade: 8, Graduated with an average score: 2.83',
    'Student name: Boby, Grade: 5, Graduated with an average score: 4.20',
    'Student name: John, Grade: 9, Graduated with an average score: 2.90',
    'Student name: Steven, Grade: 2, Graduated with an average score: 4.90',
    'Student name: Darsy, Grade: 1, Graduated with an average score: 5.15'
]);