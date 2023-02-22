using System;
using System.Collections.Generic;
using System.Linq;

Dictionary<string, string> exams = new();
SortedDictionary<string, Dictionary<string, int>> rankings = new();


string input = Console.ReadLine();
while (input != "end of contests")
{
    string[] examInfo = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
    string examName = examInfo[0];
    string examPassword = examInfo[1];

    if (!exams.ContainsKey(examName))
    {
        exams.Add(examName, examPassword);
    }

    input = Console.ReadLine();
}

input = Console.ReadLine();
while (input != "end of submissions")
{
    string[] studentInfo = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
    string exam = studentInfo[0];
    string examPassword = studentInfo[1];
    string studentName = studentInfo[2];
    int examScore = int.Parse(studentInfo[3]);
    if (!exams.ContainsKey(exam))
    {
        input = Console.ReadLine();
        continue;
    }

    if (exams[exam] != examPassword)
    {
        input = Console.ReadLine();
        continue;
    }

    if (!rankings.ContainsKey(studentName))
    {
        rankings.Add(
            studentName,
            new Dictionary<string, int> { { exam, examScore } });
    }
    else
    {
        if (!rankings[studentName].ContainsKey(exam))
        {
            rankings[studentName].Add(exam, examScore);
        }
        else
        {
            if (examScore > rankings[studentName][exam])
            {
                rankings[studentName][exam] = examScore;
            }
        }
    }

    input = Console.ReadLine();
}

var bestStudent = rankings.OrderByDescending(x => x.Value.Values.Sum()).First();
var bestStudentSum = bestStudent.Value.Values.Sum();

Console.WriteLine($"Best candidate is {bestStudent.Key} with total {bestStudentSum} points.");
Console.WriteLine("Ranking:");
foreach (var student in rankings)
{
    Console.WriteLine(student.Key);
    foreach (var studentExam in student.Value.OrderByDescending(x=>x.Value))
    {
        Console.WriteLine($"#  {studentExam.Key} -> {studentExam.Value}");
    }
}