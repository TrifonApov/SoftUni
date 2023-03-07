using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(
        int id,
        string firstName, 
        string lastName, 
        decimal salary, 
        Corps corps, 
        IReadOnlyCollection<IMission> missions) 
        : base(id, firstName, lastName, salary, corps)
    {
        Missions = missions;
    }

    public IReadOnlyCollection<IMission> Missions { get; }
}