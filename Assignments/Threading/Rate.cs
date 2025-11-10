using CalculateInterest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Interest interest = new Interest(10000, 5);
            interest.display();
            Console.ReadLine();
        }
    }
}