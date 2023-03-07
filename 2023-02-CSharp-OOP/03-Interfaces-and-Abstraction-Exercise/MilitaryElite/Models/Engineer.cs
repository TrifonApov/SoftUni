using System.Collections.Generic;
using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps, IReadOnlyCollection<IRepair> repairs) 
        : base(id, firstName, lastName, salary, corps)
    {
        Repairs = repairs;
    }

    public IReadOnlyCollection<IRepair> Repairs { get; private set; }
}