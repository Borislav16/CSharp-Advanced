using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        public BoothRepository()
        {
            models = new List<IBooth>();
        }
        private List<IBooth> models;

        public IReadOnlyCollection<IBooth> Models
        {
            get { return models.AsReadOnly(); }

        }


        public void AddModel(IBooth model)
        {
            models.Add(model);
        }
    }
}
