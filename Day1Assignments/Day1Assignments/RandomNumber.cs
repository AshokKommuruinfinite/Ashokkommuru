using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Assignments
{
    internal class RandomNumber
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Task<int> task1 = Task.Run(() => random.Next(1, 50));
            Task<int> task2 = Task.Run(() => random.Next(1, 50));
            Task<int> task3 = Task.Run(() => random.Next(1, 50));



            Task.WaitAll(task1, task2, task3);


            int sum = task1.Result + task2.Result + task3.Result;

            Console.WriteLine($"Numbers: {task1.Result}, {task2.Result}, {task3.Result}");
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine("Done!");
            Console.ReadLine();

        }
    }
}