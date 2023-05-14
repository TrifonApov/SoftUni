using System.Collections.Generic;
using System.Linq;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> models;

        public RobotRepository()
        {
            models = new List<IRobot>();
        }

        public IReadOnlyCollection<IRobot> Models()
        {
            return models.AsReadOnly();
        }

        public void AddNew(IRobot model)
        {
            models.Add(model);
        }

        public bool RemoveByName(string typeName)
        {
            IRobot modelToRemove = models.FirstOrDefault(c => c.Model == typeName);

            return models.Remove(modelToRemove);
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            return models.FirstOrDefault(r => r.InterfaceStandards.Any(s => s == interfaceStandard));
        }
    }
}