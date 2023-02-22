using System;
using System.Collections.Generic;
using System.Linq;

int entriesCount = int.Parse(Console.ReadLine());
Dictionary<string, List<double>> studentsGrades = new Dictionary<string, List<double>>();


for (int i= 0; i < entriesCount; i++)
{
    string[] entry = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string studentName = entry[0];
    double studentGrade = double.Parse(entry[1]);

    if (!studentsGrades.ContainsKey(studentName))
    {
        studentsGrades.Add(studentName, new List<double>(){studentGrade});
    }
    else
    {
        studentsGrades[studentName].Add(studentGrade);
    }
}

foreach (var (key, value) in studentsGrades)
{
    List<string> grades = new List<string>();
    foreach (double d in value)
    {
        grades.Add($"{d:0.00}");
    }

    Console.WriteLine($"{key} -> {string.Join(" ", grades)} (avg: {value.Average():0.00})");
}