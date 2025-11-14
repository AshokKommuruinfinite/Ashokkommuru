using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace UtilityBillingSystem

{

    internal class BillingSystem

    {

        public static decimal serviceCharge = 50;

        public static decimal CalculateTax(decimal amount)

        {

            return amount * 0.18m;

        }

        public static decimal CalculateUsage(params decimal[] readings)

        {

            decimal total = 0;

            foreach (var value in readings)

            {

                total += value;

            }

            return total;

        }

    }

}

