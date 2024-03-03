using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCorrectVehicles.IO.Interfaces
{
    public class FileWriter : IWriter
    {
        public void WriteLine(string str)
        {
            using StreamWriter sw = new StreamWriter("D:\\test.txt", true);

            sw.WriteLine(str);
        }
        
    }
}
