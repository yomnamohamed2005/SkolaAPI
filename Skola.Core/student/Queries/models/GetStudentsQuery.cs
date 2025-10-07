using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Skola.Data.Entities;
using Skola.Core.student.Queries.Dtos;
using Skola.Core.Bases;
namespace Skola.Core.student.Queries.models
{
	public class GetStudentsQuery : IRequest<Response<List<StudentDto>>>
	{
	}
}
