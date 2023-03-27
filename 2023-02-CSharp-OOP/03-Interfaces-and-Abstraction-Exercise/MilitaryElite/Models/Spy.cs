﻿using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models;

public class Spy : Soldier, ISpy
{
    public Spy(int id, string firstName, string lastName, int codeNumber)
        : base(id, firstName, lastName)
    {
        CodeNumber = codeNumber;
    }

    public int CodeNumber { get; private set; }
}