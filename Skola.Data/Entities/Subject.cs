using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Data.Entities
{
	public class Subject
	{
        public  int  Id { get; set; }
        public  string  NameAr { get; set; }
		public string NameEn { get; set; }
		public  DateTime Period { get; set; }
        public ICollection<DepartmentSubject> departments { get; set; } = new HashSet<DepartmentSubject>();
        public ICollection<StudentSubject> students { get; set; } = new HashSet<StudentSubject>();
        public ICollection<SubjectInstructor> Instructors { get; set; } = new HashSet<SubjectInstructor>();
    }
}
