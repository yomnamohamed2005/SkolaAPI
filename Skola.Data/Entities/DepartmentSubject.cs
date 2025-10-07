using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Data.Entities
{
	public class DepartmentSubject
	{
       
        public  int DepartmentId { get; set; }
        public Department Department { get; set; }
        public  int  SubjectId{ get; set; }
        public  Subject Subject { get; set; }
    }
}
