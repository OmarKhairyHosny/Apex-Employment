using ApexTask.DAL;
using ApexTask.DAL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApexTask.Managers.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
}
