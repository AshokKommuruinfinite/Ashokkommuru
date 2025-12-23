
using MondayAssignment;
using System;

using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MondayAssignment
{
    internal class Department
    {
        [Key]
        public int DeptID { get; set; }
        [StringLength(20)]
        public string DepartmentName { get; set; }
        [StringLength(20)]
        public string Manager { get; set; }
        [Timestamp]
        public byte[] DepartmentEdit { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }

}

