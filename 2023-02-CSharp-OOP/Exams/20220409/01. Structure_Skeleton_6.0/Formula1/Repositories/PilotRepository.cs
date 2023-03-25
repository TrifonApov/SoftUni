using System.Collections.Generic;
using System.Linq;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> models;

        public PilotRepository()
        {
            models = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => models.AsReadOnly();

        public void Add(IPilot pilot)
        {
            models.Add(pilot);
        }

        public bool Remove(IPilot pilot)
        {
            return models.Remove(pilot);
        }

        public IPilot FindByName(string fullName)
        {
            return models.FirstOrDefault(p => p.FullName == fullName);
        }
    }
}