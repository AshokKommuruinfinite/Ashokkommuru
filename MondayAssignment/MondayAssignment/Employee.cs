using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MondayAssignment
{
    internal class Employee
    {
        public string Empid { get; set; }
        [StringLength(20)]
        public string EmpName { get; set; }
        public int DeptID { get; set; }

        public int Salary { get; set; }

        public DateTime DOB { get; set; }
        [ForeignKey("DeptID")]

        public Department Department { get; set; }

    }

}


