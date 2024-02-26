using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    internal class Smartphone : ICallable, IBrowsable
    {
        public string Call(string phoneNumber)
        {
            if (IsDigit(phoneNumber))
            {
                return $"Calling... {phoneNumber}";
            }
            else
            {
                throw new ArgumentException("Invalid number!");
            }
        }

        public string Browse(string url)
        {
            if (IsLetter(url))
            {
                return $"Browsing: {url}!";
            }
            else
            {
                throw new ArgumentException("Invalid URL!");
            }
        }

        private bool IsLetter(string url)
        {
            return url.All(x => !char.IsDigit(x));
        }

        private bool IsDigit(string phoneNumber)
        {
            return phoneNumber.All(x => char.IsDigit(x));
        }

    }
}
