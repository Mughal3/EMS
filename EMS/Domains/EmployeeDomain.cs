using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMS.Domains
{
    public class EmployeeDomain
    {
        public int EID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? Salary { get; set; }
        public int? DetID { get; set; }

        public string DepartmentName { get; set; }
    }
}