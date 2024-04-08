using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class Goalkeeper : Player
    {
        public Goalkeeper(string name) : base(name, 2.5)
        {
        }

        public override void DecreaseRating()
        {
            if (Rating - 1.25 < 1)
            {
                Rating = 1;
            }
            else
            {
                Rating -= 1.25;
            }
        }

        public override void IncreaseRating()
        {
            if(Rating + 0.75 > 10)
            {
                Rating = 10;
            }
            else
            {
                Rating += 0.75;
            }
        }
    }
}
