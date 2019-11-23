using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApexTask.DAL.DataBase;
using ApexTask.Managers;

namespace ApexTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public EmployeesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/Employees
        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            return unitOfWork.EmployeeManager.GetAll().Include(e=>e.Department);
        }
        [HttpGet("GetEmployeesByDepId/{id}")]
        public IEnumerable<Employee> GetEmployeesByDepId([FromRoute] int id)
        {
            return unitOfWork.EmployeeManager.GetEmployeesByDepId(id);
        }
        // GET: api/Employees/5
        [HttpGet("{id}")]
        public IActionResult GetEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = unitOfWork.EmployeeManager.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public IActionResult PutEmployee([FromRoute] int id, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.id)
            {
                return BadRequest();
            }

            unitOfWork.EmployeeManager.Update(employee);
            unitOfWork.Save();

            return NoContent();
        }

        // POST: api/Employees
        [HttpPost]
        public IActionResult PostEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            unitOfWork.EmployeeManager.Add(employee);
            unitOfWork.Save();
            return CreatedAtAction("GetEmployee", new { id = employee.id }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = unitOfWork.EmployeeManager.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            unitOfWork.EmployeeManager.Delete(employee);
            unitOfWork.Save();
            return Ok(employee);
        }
 
    }
}