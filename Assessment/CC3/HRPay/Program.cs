using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HRPay
{
    // Employee model
    internal class EmployeeRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public bool IsVeteran { get; set; }
    }

    // Interface for data reader
    internal interface IEmployeeDataReader
    {
        EmployeeRecord GetEmployeeRecord(int employeeId);
    }

    // Mock implementation
    internal class MockEmployeeDataReader : IEmployeeDataReader
    {
        public EmployeeRecord GetEmployeeRecord(int employeeId)
        {
            switch (employeeId)
            {
                case 101:
                    return new EmployeeRecord
                    {
                        Id = 101,
                        Name = "Ashok",
                        Role = "Developer",
                        IsVeteran = true
                    };
                case 102:
                    return new EmployeeRecord
                    {
                        Id = 102,
                        Name = "Kommuru",
                        Role = "Manager",
                        IsVeteran = false
                    };
                case 103:
                    return new EmployeeRecord
                    {
                        Id = 103,
                        Name = "Avinash",
                        Role = "Intern",
                        IsVeteran = false
                    };
                default:
                    return new EmployeeRecord
                    {
                        Id = employeeId,
                        Name = "Unknown",
                        Role = "Other",
                        IsVeteran = false
                    };
            }
        }
    }

    // Payroll processor
    internal class PayrollProcessor
    {
        private readonly IEmployeeDataReader dataReader;

        // Dictionary initializer for base salaries
        private static readonly Dictionary<int, decimal> BaseSalaries =
            new Dictionary<int, decimal>
            {
                [101] = 65000m,
                [102] = 120000m,
                [103] = 30000m
            };

        // Constructor Injection
        public PayrollProcessor(IEmployeeDataReader dataReader)
        {
            this.dataReader = dataReader;
        }

        public decimal CalculateTotalCompensation(int employeeId)
        {
            var emp = dataReader.GetEmployeeRecord(employeeId);

            decimal bonus = 0m;

            // Bonus calculation using switch
            switch (emp.Role)
            {
                case "Manager":
                    bonus = emp.IsVeteran ? 10000m : 5000m;
                    break;

                case "Developer":
                    bonus = 2000m;
                    break;

                case "Intern":
                    bonus = 500m;
                    break;

                default:
                    bonus = 0m;
                    break;
            }

            // Get base salary from dictionary
            decimal baseSalary = 0m;
            BaseSalaries.TryGetValue(employeeId, out baseSalary);

            return baseSalary + bonus;
        }
    }

    // Main program
    internal class Program
    {
        static void Main(string[] args)
        {
            IEmployeeDataReader reader = new MockEmployeeDataReader();
            PayrollProcessor payroll = new PayrollProcessor(reader);

            int[] ids = { 101, 102, 103, 999 };

            foreach (int id in ids)
            {
                decimal total = payroll.CalculateTotalCompensation(id);
                Console.WriteLine($"Employee {id} Compensation is --> {total:C}");
            }

            Console.ReadLine();
        }
    }
}


