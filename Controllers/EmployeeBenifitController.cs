using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STW_demo_ODATA.Controllers
{
    public class EmployeeBenifitController : Controller
    {
        private readonly Razor_EmployeeContext db;
        public EmployeeBenifitController(Razor_EmployeeContext _db)
        {
            db = _db;
        }
        [HttpGet]
        [EnableQuery()]
        public IEnumerable<EmployeeBenifit> Get()
        {
            return db.EmployeeBenifits;
        }

    }
}
