using ApexTask.DAL.DataBase;
using ApexTask.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApexTask.Managers
{
    public interface IUnitOfWork  
    {
        DepartmentManager DepartmentManager { get; }
        TaskManager TaskManager { get; }
        EmployeeManager EmployeeManager { get; }
        int Save();
    }
}
