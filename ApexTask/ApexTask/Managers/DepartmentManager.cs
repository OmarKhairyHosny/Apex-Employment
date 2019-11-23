using ApexTask.DAL;
using ApexTask.DAL.DataBase;
using ApexTask.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApexTask.Managers
{
    public class DepartmentManager : Repository<Department>
    {
        public DepartmentManager(CompanyDB ctx) : base(ctx)
        {
        }
    }
}
