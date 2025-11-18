using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Assignments
{
    internal class FactorialNumber
    {
        public static int Factorial()
        {
            int num = 5;
            int fact = 1;
            for (int i = num; i > 0; i--)
            {
                fact *= i;
            }
            return fact;
        }
        static void Main(string[] args)
        {
            Task<int> factorial = Task.Run(() => Factorial());
            int result = factorial.Result;

            Console.WriteLine("Factorial of the Number is : " + result);
            Console.ReadLine();
        }
    }
}

 
    

