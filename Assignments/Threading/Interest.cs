using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace CalculateInterest

{

    internal class Interest

    {

        int principle, year, rate;

        public Interest(int p, int r)

        {

            principle = p;

            year = 1;

            rate = r;

        }

        public void CalculateSimpleInterest()

        {

            Console.WriteLine("Enter the Principle Amount : ");

            principle = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enetr the rate percent : ");

            rate = Convert.ToInt32(Console.ReadLine());

        }

        public void display()

        {

            double simpleInterest = (principle * year * rate) / 100;

            Console.WriteLine("Simple interest is : " + simpleInterest);

        }

    }

}


