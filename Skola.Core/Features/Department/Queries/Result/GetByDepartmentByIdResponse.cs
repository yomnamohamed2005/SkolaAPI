using Skola.Core.Wapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Core.Fearures.Department.Queries
{
    public class GetByDepartmentByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public PaginatedResult<studentresponse>? StudentList { get; set; }
        public List<subjectresponse>SubjectList {get; set;}
        public List<instructorresponse>? InstructorList { get; set; }

    }
    public class  studentresponse 
    {
        public  int  Id { get; set; }

        public  string  Name { get; set; }

        public studentresponse(int id , string name )
        {
            Id = id;
            Name = name;
            
        }
    }

    public class subjectresponse
    {
        public  int  Id { get; set; }

        public string Name { get; set; }
    }

    public class  instructorresponse
    {
        public  int  Id { get; set; }

        public string Name { get; set; }

    }
}
