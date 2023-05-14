using System.Collections.Generic;
using System.Linq;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private List<ISupplement> models;

        public SupplementRepository()
        {
            models = new List<ISupplement>();
        }


        public IReadOnlyCollection<ISupplement> Models()
        {
            return models.AsReadOnly();
        }

        public void AddNew(ISupplement model)
        {
            models.Add(model);
        }

        public bool RemoveByName(string typeName)
        {
            ISupplement modelToRemove = models.FirstOrDefault(c => c.GetType().Name == typeName);

            return models.Remove(modelToRemove);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            return models.FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);
        }
    }
}