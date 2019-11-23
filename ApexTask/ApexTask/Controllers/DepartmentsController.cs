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
    public class DepartmentsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        
        public DepartmentsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/Departments
        [HttpGet]
        public IEnumerable<Department> GetDepartments()
        {
            return unitOfWork.DepartmentManager.GetAll().ToList();
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public IActionResult GetDepartment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var department =  unitOfWork.DepartmentManager.GetById(id);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public IActionResult PutDepartment([FromRoute] int id, [FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != department.id)
            {
                return BadRequest();
            }

            unitOfWork.DepartmentManager.Update(department);
            unitOfWork.Save();

            return NoContent();
        }

        // POST: api/Departments
        [HttpPost]
        public  IActionResult PostDepartment([FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

             unitOfWork.DepartmentManager.Add(department);
            unitOfWork.Save();

            return CreatedAtAction("GetDepartment", new { id = department.id }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var department = unitOfWork.DepartmentManager.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            unitOfWork.DepartmentManager.Delete(department);
            unitOfWork.Save();
            return Ok(department);
        }

         
    }
}