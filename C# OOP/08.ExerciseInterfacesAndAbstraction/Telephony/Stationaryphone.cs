using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class Stationaryphone : ICallable
    {
        public string Call(string phoneNumber)
        {
            if (IsDigit(phoneNumber))
            {

                return $"Dialing... {phoneNumber}";

            }
            else
            {
                throw new ArgumentException("Invalid number!");
            }

        }
        private bool IsDigit(string phoneNumber)
        {
            return phoneNumber.All(x => char.IsDigit(x));
        }
    }
}
