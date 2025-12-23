using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityframework
{
    public class Ipl
    {
        [Key]// now team is primary key
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string Captain { get; set; }
        public string State { get; set; }
    }
}