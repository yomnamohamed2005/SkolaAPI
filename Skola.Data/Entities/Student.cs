using Skola.Data.Commens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Data.Entities
{
	public class Student : GlobalLocalizaleEntity
	{
        public int Id { get; set; }
        public string NameAr { get; set; }
		public string NameEn { get; set; }
		public  string  Address{ get; set; }
        public string PhoneNumber { get; set; }
        public  int  DepartmentId { get; set; }
        public  Department Department { get; set; }
        public ICollection<StudentSubject> subjects { get; set; } = new HashSet<StudentSubject>();
    }
}
