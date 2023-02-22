using System;
using System.Collections.Generic;
using System.Linq;

Dictionary<string, int> students = new();
Dictionary<string, int> exams = new();
HashSet<string> bannedStudents = new HashSet<string>();
string inputData = Console.ReadLine();
while (inputData != "exam finished")
{
    string[] submissionInfo = inputData.Split("-", StringSplitOptions.RemoveEmptyEntries);
    string studentName = submissionInfo[0];

    if (submissionInfo[1] == "banned")
    {
        bannedStudents.Add(studentName);
        inputData = Console.ReadLine();
        continue;
    }

    string exam = submissionInfo[1];
    int score = int.Parse(submissionInfo[2]);

    if (!students.ContainsKey(studentName))
    {
        students.Add(studentName, score);
    }
    else
    {
        if (score > students[studentName])
        {
            students[studentName] = score;
        }
    }

    if (!exams.ContainsKey(exam))
    {
        exams.Add(exam, 1);
    }
    else
    {
        exams[exam]++;
    }


    inputData = Console.ReadLine();
}

Console.WriteLine("Results:");

foreach (var student in students.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
{
    if (bannedStudents.Contains(student.Key))
    {
        continue;
    }
    Console.WriteLine($"{student.Key} | {student.Value}");
}

Console.WriteLine("Submissions:");

foreach (var exam in exams.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    Console.WriteLine($"{exam.Key} - {exam.Value}");
}