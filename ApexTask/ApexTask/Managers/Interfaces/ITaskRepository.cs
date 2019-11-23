using ApexTask.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApexTask.Managers.Interfaces
{
    public interface ITaskRepository:IRepository<ApexTask.DAL.DataBase.Task>
    {
    }
}
