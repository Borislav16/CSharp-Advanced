using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public class ScubaDiver : Diver
    {
        public ScubaDiver(string name) : base(name, 540)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            double percentage = TimeToCatch * 0.30;
            OxygenLevel -= (int)Math.Round(percentage, MidpointRounding.AwayFromZero);
            if(OxygenLevel <= 0)
            {
                if(!HasHealthIssues)
                {
                    UpdateHealthStatus();
                }
            }
        }

        public override void RenewOxy()
        {
            OxygenLevel = 540;
        }
    }
}
