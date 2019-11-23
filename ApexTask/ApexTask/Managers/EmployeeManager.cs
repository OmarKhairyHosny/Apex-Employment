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
    public class EmployeeManager : Repository<Employee>
    {
        public EmployeeManager(CompanyDB ctx) : base(ctx)
        {
        }
        public IEnumerable<Employee> GetEmployeesByDepId(int id)
        { 
            return GetAll().Include(e => e.Department).Where(e => e.DepartmentId == id);
        }
        
    }
}
