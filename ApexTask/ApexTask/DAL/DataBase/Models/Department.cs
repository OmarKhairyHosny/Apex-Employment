using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApexTask.DAL.DataBase
{
    public class Department
    { 
        public Department()
        {
            this.Employees = new HashSet<Employee>();
        }
        [Key]
         
        public int id { get; set; }
        [Required]
        public string DepartmentName_En { get; set; }
        [Required]
        public string DepartmentName_Ar { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
