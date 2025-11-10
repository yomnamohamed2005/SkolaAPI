using MediatR;
using Skola.Core.Bases;
using Skola.Core.Fearures.Department.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Core.Fearures.Department.Queries
{
	public class GetDepartmentByIdRequest :IRequest<Response<GetByDepartmentByIdResponse>>
	{
        public  int  Id { get; set; }
        public  int  StudentPageSize { get; set; }

        public int StudentPageNumber { get; set; }


    }
}
