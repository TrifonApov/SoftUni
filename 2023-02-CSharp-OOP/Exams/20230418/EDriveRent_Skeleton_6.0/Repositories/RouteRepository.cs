using System.Collections.Generic;
using System.Linq;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        private readonly List<IRoute> routes;

        public RouteRepository()
        {
            routes = new List<IRoute>();
        }

        public void AddModel(IRoute model)
        {
            routes.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            return routes.Remove(routes.Single(route => route.RouteId == int.Parse(identifier)));
        }

        public IRoute FindById(string identifier)
        {
            return routes.FirstOrDefault(route => route.RouteId == int.Parse(identifier));

        }

        public IReadOnlyCollection<IRoute> GetAll()
        {
            return routes.AsReadOnly();
        }
    }
}