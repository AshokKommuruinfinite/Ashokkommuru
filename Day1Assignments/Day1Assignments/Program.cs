using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Day1Assignments
{
    internal class Program
    {
        public void method1()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Number :  " + i);
            }
        }
        public void method2()
        {
            for (int i = 6; i <= 10; i++)
            {
                Console.WriteLine("Number :  " + i);
            }
        }
        public void method3()
        {
            Console.WriteLine("All numbers printed!");
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Task task1 = new Task(p.method1);
            task1.Start();
            Task task2 = new Task(p.method2);
            task2.Start();

            Task task3 = new Task(p.method3);
            task3.Start();
            Task.WaitAll(task1, task2, task3);
            Console.WriteLine("Done");

            Console.ReadLine();

        }
    }
}
