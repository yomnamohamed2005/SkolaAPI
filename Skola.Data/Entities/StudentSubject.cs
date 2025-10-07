using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Data.Entities
{
	public class StudentSubject
	{
       
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public  Subject Subject { get; set; }
        public  int  SubjectId { get; set; }
        public  decimal Grade { get; set; }
    }
}
