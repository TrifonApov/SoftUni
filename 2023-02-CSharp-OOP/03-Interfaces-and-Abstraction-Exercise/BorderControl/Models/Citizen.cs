using System;

namespace BorderControl.Models;

public class Citizen: IIdentification, IBirthday
{
    private string id;
    private string name;
    public int age;
    private DateTime birthDay;

    public Citizen(string id, string name, int age, DateTime birthDay)
    {
        Id = id;
        Name = name;
        Age = age;
        BirthDay = birthDay;
    }

    public string Id
    {
        get => id;
        set => id = value;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public int Age
    {
        get => age;
        set => age = value;
    }

    public DateTime BirthDay
    {
        get => birthDay;
        set => birthDay = value;
    }
}