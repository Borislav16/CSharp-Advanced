using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {

        public PlayerRepository()
        {
            models = new List<IPlayer>();
        }
        private List<IPlayer> models;

        public IReadOnlyCollection<IPlayer> Models
        {
            get { return models.AsReadOnly(); }
            
        }

        public void AddModel(IPlayer model)
        {
            models.Add(model);
        }

        public bool ExistsModel(string name)
        {
            var model = models.FirstOrDefault(m => m.Name == name);
            if(model != null)
            {
                return true;
            }
            return false;
        }

        public IPlayer GetModel(string name)
        {
            return models.FirstOrDefault(m => m.Name == name);
        }

        public bool RemoveModel(string name)
        {
            return models.Remove(models.FirstOrDefault(m => m.Name == name));
        }
    }
}
