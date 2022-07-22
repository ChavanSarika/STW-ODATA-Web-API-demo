using System;
using System.Collections.Generic;

#nullable disable

namespace STW_demo_ODATA
{
    public partial class Benifit
    {
        public Benifit()
        {
            EmployeeBenifits = new HashSet<EmployeeBenifit>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public virtual ICollection<EmployeeBenifit> EmployeeBenifits { get; set; }
    }
}
