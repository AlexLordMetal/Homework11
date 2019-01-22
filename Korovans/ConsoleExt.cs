using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korovans
{
    class ConsoleExt
    {
        public static int ReadLineToInt(int maxValue = Int32.MaxValue)
        {
            var correct = false;
            var result = 0;
            while (!correct)
            {
                if (Int32.TryParse(Console.ReadLine(), out result) && result >= 0 && result < maxValue)
                {
                    correct = true;
                }
                else
                {
                    correct = false;
                    Console.WriteLine("The data entered is not correct!\nTry again.");
                }
            }
            return result;
        }
    }
}