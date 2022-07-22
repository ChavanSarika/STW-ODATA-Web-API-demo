using System;
using System.Collections.Generic;

#nullable disable

namespace STW_demo_ODATA
{
    public partial class EmployeeBenifit
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int BenifitId { get; set; }
        public DateTime Fromdate { get; set; }
        public virtual Benifit Benifit { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
