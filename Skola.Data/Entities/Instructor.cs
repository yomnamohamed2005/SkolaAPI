using Skola.Data.Commens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Data.Entities
{
	public class Instructor : GlobalLocalizaleEntity
	{
        public  int  Id { get; set; }
        public  string  NameAr { get; set; }
        public string NameEn { get; set; }
        
        public  string  Address { get; set; }
        public  string  Postion { get; set; }
        public  decimal  Salary { get; set; }

        public  int  DepartmentId { get; set; }
        public  Department Department { get; set; }

        public  int ? SupervisorId { get; set; }
		public Instructor Supervisor { get; set; }

		public Department ManagerDepartment { get; set; }

		public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();

        public ICollection<SubjectInstructor> Subjects { get; set; } = new HashSet<SubjectInstructor>();
    }
}
