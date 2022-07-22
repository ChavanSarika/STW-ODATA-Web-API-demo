using System;
using System.Collections.Generic;

#nullable disable

namespace STW_demo_ODATA
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeBenifits = new HashSet<EmployeeBenifit>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public string City { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<EmployeeBenifit> EmployeeBenifits { get; set; }
    }
}
