using STW_demo_ODATA.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STW_demo_ODATA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class EmployeeController : ODataController
    {

        private readonly Razor_EmployeeContext db;
        public EmployeeController(Razor_EmployeeContext _db)
        {
            db = _db;
        }
        [HttpGet]
        [EnableQuery()]
        public IEnumerable<Employee> Get() 
        {
            return db.Employees;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employees.Add(emp);
            await db.SaveChangesAsync();
            return Created(emp);
        }
        [HttpPatch]
        public async Task<IActionResult> Patch([FromODataUri] int key, [FromBody]Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Employees.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            db.Employees.Update(emp);
            await db.SaveChangesAsync();
            return Updated(emp);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromODataUri] int key, [FromBody] Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Employees.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            db.Employees.Update(emp);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(emp);
        }
        private bool EmployeeExists(int key)
        {
            return db.Employees.Any(x => x.Id == key);
        }
        [HttpDelete]
        [EnableQuery]
        public async Task<IActionResult> Delete([FromODataUri] int key)
        {
            Employee existingemp = await db.Employees.FindAsync(key);
            if (existingemp == null)
            {
                return NotFound();
            }

            db.Employees.Remove(existingemp);
            await db.SaveChangesAsync();
            return StatusCode(StatusCodes.Status204NoContent);
        }

        private bool NoteExists(int key)
        {
            return db.Employees.Any(p => p.Id == key);
        }
    }
}
