using ApexTask.DAL;
using ApexTask.DAL.DataBase;
using ApexTask.Managers.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApexTask.Managers
{
    public class TaskManager : Repository<DAL.DataBase.Task>
    {
        public TaskManager(CompanyDB ctx) : base(ctx)
        {
        }
        public IEnumerable<DAL.DataBase.Task> GetTasksByEmpId(int id)
        {
            return GetAll().Include(e => e.Employee).Where(e => e.EmployeeId == id);
        }
    }
}
