function solve(input) {
    var courses = {};
    var allData = [];
    for (var i = 0; i < input.length; i++) {
        allData[i] = input[i].match(/([A-z]+\s[A-z]+)|([A-Za-z#+]+?\s[A-Za-z#+]+)|([A-Za-z#+]+)|([\d.]+)|([\d]+)/g);
    }

    for (i = 0; i < allData.length; i++) {
        if (!courses.hasOwnProperty(allData[i][1])) {
            courses[allData[i][1]] = {
                avgGrade : parseFloat(allData[i][2]),
                avgVisits : parseFloat(allData[i][3]),
                students : [allData[i][0]]
            };
        } else {
            var currerntGrade = courses[allData[i][1]].avgGrade;
            currerntGrade += parseFloat(allData[i][2]);
            var currentVisit = courses[allData[i][1]].avgVisits;
            currentVisit += parseFloat(allData[i][3]);
            var currStudent = courses[allData[i][1]].students;
            currStudent.push(allData[i][0]);
            courses[allData[i][1]] = {
                avgGrade : currerntGrade,
                avgVisits : currentVisit,
                students : currStudent
            }
        }
    }
    var sortCourses = {};
    var keys = [];
    var k, j,len;
    for (k in courses) {
        if (courses.hasOwnProperty(k)) {
            keys.push(k);
        }
    }
    keys.sort();
    len = keys.length;
    for (j = 0; j < len; j++) {
        k = keys[j];
        sortCourses[k] = courses[k];
    }
    for (var obj in sortCourses) {
        sortCourses[obj].avgGrade = parseFloat(Math.round((sortCourses[obj].avgGrade / sortCourses[obj].students.length)*100)/100);
        sortCourses[obj].avgVisits = parseFloat(Math.round((sortCourses[obj].avgVisits / sortCourses[obj].students.length)*100)/100);
    }
    for (var obj in sortCourses) {
        var studentsArray = [];
        studentsArray = sortCourses[obj].students;
        studentsArray = studentsArray.filter(function (a,b) {
            return studentsArray.indexOf(a) == b;
        });
        sortCourses[obj].students = studentsArray;
    }
    for (var obj in sortCourses) {
        var studentsArray = [];
        studentsArray = sortCourses[obj].students;
        studentsArray = studentsArray.sort();
        sortCourses[obj].students = studentsArray;
    }
    return JSON.stringify(sortCourses);
}
console.log(solve(['Milen Georgiev|PHP|2.02|2',
    'Ivan Petrov|C# Basics|3.20|22',
    'Peter Nikolov|C#|5.522|18',
    'Maria Kirova|C# Basics|2.20|4',
    'Stanislav Peev|C#|4.12|15',
    'Ivan Petrov|PHP|5.120|6',
    'Ivan Goranov|SQL|5.926|12',
    'Todor Kirov|PHP|5.50|0',
    'Maria Ivanova|Java|5.83|37',
    'Maria Ivanova|C#|1.823|4',
    'Stanislav Peev|C#|4.122|15',
    'Ivan Petrov|PHP|5.11|6',
    'Ivan Petrov|SQL|5.926|12',
    'Peter Nikolov|Java|5.9996|9',
    'Stefan Nikolov|Java|4.00|9']));

// {
//      "C#":{
//           "avgGrade":4.61,
//           "avgVisits":5.5,
//           "students":["Ivan Petrov","Maria Ivanova","Peter Nikolov"]
//      },
//      "Java":{
//           "avgGrade":5.92,
//           "avgVisits":8,
//           "students":["Maria Ivanova","Peter Nikolov"]
//      },
//      "PHP":{
//           "avgGrade":3.87,
//           "avgVisits":4,
//           "students":["Ivan Petrov","Peter Nikolov"]
//      }
// }