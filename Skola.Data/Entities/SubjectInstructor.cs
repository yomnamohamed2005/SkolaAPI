using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Data.Entities
{
	public  class SubjectInstructor
	{
        public int  SubjectId{ get; set; }
        public  Subject Subject { get; set; }

        public int InstructorId { get; set; }
        public  Instructor Instructor { get; set; }
    }
}
