using MediatR;
using Skola.Core.Bases;
using Skola.Core.student.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Core.student.Queries.models
{
	public class GetStudentQuery :IRequest<Response<StudentDto>>
	{
        public  int  Id { get; set; }
        public GetStudentQuery(int id)
        {
            Id = id;
        }
    }
}
