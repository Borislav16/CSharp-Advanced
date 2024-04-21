using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Repositories
{
    public class ClimberRepository : IRepository<IClimber>
    {
        public ClimberRepository()
        {
            all = new List<IClimber>();
        }
        private List<IClimber> all;
        public IReadOnlyCollection<IClimber> All => all.AsReadOnly();

        public void Add(IClimber model)
        {
            all.Add(model);
        }

        public IClimber Get(string name)
        {
            return all.FirstOrDefault(a => a.Name == name);
        }
    }
}
