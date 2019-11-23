using ApexTask.DAL.DataBase;
using ApexTask.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApexTask.Managers
{
    public class UnitOfWork : IUnitOfWork
    {

        #region field
        private readonly CompanyDB companyDB;

        #endregion

        #region Constructor
        public UnitOfWork(CompanyDB companyDB)
        {
            this.companyDB = companyDB;
        } 
        #endregion

        #region Properties
        private DepartmentManager departmentManager;
        public DepartmentManager DepartmentManager
        {
            get
            {
                if (departmentManager == null)
                    departmentManager = new DepartmentManager(companyDB);
                return departmentManager;
            }
        }

        private EmployeeManager employeeManager;
        public EmployeeManager EmployeeManager
        {
            get
            {
                if (employeeManager == null)
                    employeeManager = new EmployeeManager(companyDB);
                return employeeManager;
            }
        }

        private TaskManager taskManager;
        public TaskManager TaskManager
        {
            get
            {
                if (taskManager == null)
                    taskManager = new TaskManager(companyDB);
                return taskManager;
            }
        }
        #endregion

        #region public Methods
        public int Save()
        {
            return companyDB.SaveChanges();
        }
         
        public void Dispose()
        {
            companyDB.Dispose();
        }
        #endregion
    }
}
