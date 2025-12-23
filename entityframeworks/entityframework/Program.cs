using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityframework
{
    internal class Program
    {
        static void Main(string[] args)
        
            {
                EtyFrm demo = new EtyFrm();
                demo.Insert();
                demo.Display();
                Console.ReadLine();
            }
        
    }
}