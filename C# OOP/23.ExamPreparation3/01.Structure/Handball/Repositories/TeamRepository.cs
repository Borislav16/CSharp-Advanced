using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        public TeamRepository()
        {
            models = new List<ITeam>();
        }
        private List<ITeam> models;

        public IReadOnlyCollection<ITeam> Models
        {
            get { return models.AsReadOnly(); }

        }

        public void AddModel(ITeam model)
        {
            models.Add(model);
        }

        public bool ExistsModel(string name)
        {
            var model = models.FirstOrDefault(m => m.Name == name);
            if (model != null)
            {
                return true;
            }
            return false;
        }

        public ITeam GetModel(string name)
        {
            return models.FirstOrDefault(m => m.Name == name);
        }

        public bool RemoveModel(string name)
        {
            return models.Remove(models.FirstOrDefault(m => m.Name == name));
        }
    }
}
