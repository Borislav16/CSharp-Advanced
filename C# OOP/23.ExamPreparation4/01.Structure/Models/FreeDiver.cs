using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public class FreeDiver : Diver
    {
        public FreeDiver(string name) : base(name, 120)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            double percentage = TimeToCatch * 0.60;
            OxygenLevel -= (int)Math.Round(percentage, MidpointRounding.AwayFromZero);
            if (OxygenLevel <= 0)
            {
                if (!HasHealthIssues)
                {
                    UpdateHealthStatus();
                }
            }
        }

        public override void RenewOxy()
        {
            OxygenLevel = 120;
        }
    }
}
