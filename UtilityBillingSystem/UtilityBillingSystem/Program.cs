using System;

namespace UtilityBillingSystem

{

    class Program

    {

        static void Main()

        {

            Console.WriteLine("Utility Billing System");

            Console.Write("Enter no of customers: ");

            int count = Convert.ToInt16(Console.ReadLine());

            for (int i = 0; i < count; i++)

            {

                Console.WriteLine($"Enter details for Customer {i + 1}");

                Console.Write("Customer Name: ");

                string name = Console.ReadLine();

                Console.Write("Monthly Usage Readings (in units, space-separated): ");

                string[] input = Console.ReadLine().Split(' ');

                decimal[] readings = Array.ConvertAll(input, Convert.ToDecimal);

                Customer customer = new Customer(name);

                customer.CalculateBill(out decimal total, out decimal tax, out decimal netPayable, readings);

                customer.PrintInvoice(total, tax, netPayable);

            }

            Console.WriteLine("All customer bills processed Successfully");

            Console.ReadLine();

        }

    }

}

