using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApexTask.DAL.DataBase
{
    public class Employee
    {
        public Employee()
        {
            this.Tasks = new HashSet<Task>();
        }
        [Key]
        public int id { get; set; }
        [Required]
        public string Name_En { get; set; }
        [Required]
        public string Name_Ar { get; set; }
        public DateTime? JoinDate { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public Employee Manager { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }

    }
}
