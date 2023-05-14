namespace EDriveRent.Repositories
{
    using EDriveRent.Models.Contracts;
    using EDriveRent.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    public class RouteRepository : IRepository<IRoute>
    {
        private List<IRoute> routes;
        public RouteRepository()
        {
            this.routes = new List<IRoute>();
        }
        public void AddModel(IRoute route)
        {
            this.routes.Add(route);
        }

        public IRoute FindById(string identifier) => this.routes.FirstOrDefault(u => u.RouteId == int.Parse(identifier));

        public IReadOnlyCollection<IRoute> GetAll() => this.routes;

        public bool RemoveById(string identifier) => this.routes.Remove(this.FindById(identifier));
    }
}
