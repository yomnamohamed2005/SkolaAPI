using Skola.Data.Commens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Data.Entities
{
	public class Department: GlobalLocalizaleEntity
	{
        
        public  int  Id { get; set; }
        public  string  NameAr { get; set; }
        public string NameEn { get; set; }

        public  int ?  DepartmentManagerId { get; set; }

        public Instructor DepartmentManager { get; set; }

        public ICollection<Student> Student { get; set; } = new HashSet<Student>();
        public ICollection<DepartmentSubject> Subjects { get; set; } = new HashSet<DepartmentSubject>();

        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();

    }
}
