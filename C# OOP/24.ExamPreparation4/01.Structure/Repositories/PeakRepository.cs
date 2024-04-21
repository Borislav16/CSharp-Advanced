using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Repositories
{
    public class PeakRepository : IRepository<IPeak>
    {
        public PeakRepository()
        {
            all = new List<IPeak>();
        }
        private List<IPeak> all;
        public IReadOnlyCollection<IPeak> All => all.AsReadOnly();

        public void Add(IPeak model)
        {
            all.Add(model);
        }

        public IPeak Get(string name)
        {
            return all.FirstOrDefault(a => a.Name == name);
        }
    }
}
