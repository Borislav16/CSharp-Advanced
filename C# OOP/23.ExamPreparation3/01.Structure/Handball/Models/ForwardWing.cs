using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class ForwardWing : Player
    {
        public ForwardWing(string name) : base(name, 5.5)
        {
        }

        public override void DecreaseRating()
        {
            if (Rating - 0.75 < 1)
            {
                Rating = 1;
            }
            else
            {
                Rating -= 0.75;
            }
        }

        public override void IncreaseRating()
        {
            if (Rating + 1.25 > 10)
            {
                Rating = 10;
            }
            else
            {
                Rating += 1.25;
            }
        }
    }
}
