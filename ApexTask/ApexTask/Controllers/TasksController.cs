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
    public class TasksController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public TasksController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/Tasks
        [HttpGet]
        public IEnumerable<DAL.DataBase.Task> GetTasks()
        {
            return unitOfWork.TaskManager.GetAll().Include(t=>t.Employee);
        }
        [HttpGet("GetTasksByEmpId/{id}")]
        public IEnumerable<DAL.DataBase.Task> GetTasksByEmpId([FromRoute] int id)
        {
            return unitOfWork.TaskManager.GetTasksByEmpId(id);
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public IActionResult GetTask([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = unitOfWork.TaskManager.GetById(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public IActionResult PutTask([FromRoute] int id, [FromBody] DAL.DataBase.Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.Id)
            {
                return BadRequest();
            }

            unitOfWork.TaskManager.Update(task);
            unitOfWork.Save();
            return NoContent();
        }

        // POST: api/Tasks
        [HttpPost]
        public IActionResult PostTask([FromBody] DAL.DataBase.Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            unitOfWork.TaskManager.Add(task);
            unitOfWork.Save();

            return CreatedAtAction("GetTask", new { id = task.Id }, task);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTask([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = unitOfWork.TaskManager.GetById(id);
            if (task == null)
            {
                return NotFound();
            }
            unitOfWork.TaskManager.Delete(task);
            unitOfWork.Save();

            return Ok(task);
        }
 
    }
}