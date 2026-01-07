using System;

using System.Collections;

using System.Collections.Generic;

using System.Linq;

using System.Runtime.InteropServices;

using System.Text;

using System.Threading.Tasks;

using System.Xml.Linq;

namespace EmployeeManagementSystem

{

    internal class Program

    {

        static void Main(string[] args)

        {

            List<Employee> employeesList = new List<Employee>

            {

                  new Employee{Id=1, Name="Ashok", Department="IT", Salary=30000, Experience=1},

                  new Employee{Id=2, Name= "Kommuru", Department= "HR", Salary = 80000, Experience=2 },

                  new Employee{Id=3, Name="Ajay", Department="Lead", Salary=75000, Experience=8},

                  new Employee{Id=4, Name="Vijay", Department="Associate Software Engineer", Salary=70000, Experience=3},

                  new Employee{Id=5, Name="Avinash", Department="Senior Developer ", Salary=40000, Experience=6},

                  new Employee{Id=6, Name="Rama", Department="Finance", Salary=70000, Experience=5},

                  new Employee{Id=7, Name="Vishnu", Department="IT", Salary=80000, Experience=10},

                  new Employee{Id=8, Name="Ashok", Department="Testing", Salary=60000, Experience=6},

                  new Employee{Id=9, Name="krishna", Department="Sales", Salary=50000, Experience=7},

                  new Employee{Id=10, Name="Babu", Department="Trainee", Salary=30000, Experience=1}


            };

            

            var HighSalary = employeesList.Where(e => e.Salary > 50000);

            var ITEmployees = employeesList.Where(e => e.Department == "IT");

            var experienceEmployees = employeesList.Where(e => e.Experience > 5);

            var nameStartsWithA = employeesList.Where(e => e.Name.StartsWith("A"));

           

            var sortByName = employeesList.OrderBy(e => e.Name);

            var sortBySalary = employeesList.OrderByDescending(e => e.Salary);

            var sortByExperience = employeesList.OrderBy(e => e.Experience);

            

            Console.WriteLine("\n-----Employee Managenment System-----");

            Console.WriteLine("\n.....Details of All Employees.....");

            foreach (var employee in employeesList)

            {

                Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Dept: {employee.Department}, Salary: {employee.Salary}, Exp: {employee.Experience} years");

            }

            Console.WriteLine("\n.... Employees with Salary > 50,000 .....");

            foreach (var e in HighSalary)

            {

                Console.WriteLine($"ID:{e.Id}, Name:{e.Name}, Dept:{e.Department}, Salary:{e.Salary}, Exp:{e.Experience} years");

            }

            Console.WriteLine("\n....Employees in IT Department....");

            foreach (var e in ITEmployees)

            {

                Console.WriteLine($"ID:{e.Id}, Name:{e.Name}, Dept:{e.Department}, Salary:{e.Salary}, Exp:{e.Experience} years");

            }

            Console.WriteLine("\n....Employees with Experience > 5 years....");

            foreach (var e in experienceEmployees)

            {

                Console.WriteLine($"ID:{e.Id}, Name:{e.Name}, Dept:{e.Department}, Salary:{e.Salary}, Exp:{e.Experience} years");

            }

            Console.WriteLine("\n....Employees whose name starts with 'A' ....");

            foreach (var e in nameStartsWithA)

            {

                Console.WriteLine($"ID:{e.Id} , Name: {e.Name} , Dept: {e.Department}, Salary:{e.Salary}, Exp:{e.Experience} years");

            }

            

            Console.WriteLine("\n.....Sorted by Name (A–Z) .....");

            foreach (var e in sortByName)

            {

                Console.WriteLine($"ID:{e.Id}, Name:{e.Name}, Dept:{e.Department}, Salary:{e.Salary}, Exp:{e.Experience} years");

            }

            Console.WriteLine("\n....Sorted by Salary (High to Low) ....");

            foreach (var e in sortBySalary)

            {

                Console.WriteLine($"ID:{e.Id}, Name:{e.Name}, Dept:{e.Department}, Salary:{e.Salary}, Exp:{e.Experience} years");

            }

            Console.WriteLine("\n....Sorted by Experience (Low to High) ....");

            foreach (var e in sortByExperience)

            {

                Console.WriteLine($"ID:{e.Id} , Name: {e.Name} , Dept: {e.Department}, Salary:{e.Salary}, Exp:{e.Experience} years");

            }

            

            Func<Employee, bool> promotionCriteria = e => e.Experience > 5 && e.Salary < 60000;

            var promotionList = employeesList.Where(promotionCriteria);

            Console.WriteLine("\n....Promotion List ....");

            foreach (var e in promotionList)

            {

                Console.WriteLine($"ID:{e.Id}, Name:{e.Name}, Dept:{e.Department}, Salary:{e.Salary}, Exp:{e.Experience} years");

            }

            Console.WriteLine("\n----- Employee Managenment System Exit -------");

            Console.ReadLine();

        }

    }

}


















