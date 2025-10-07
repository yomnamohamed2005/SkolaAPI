using MediatR;
using Skola.Core.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Core.student.commands.models
{
	public class AddStudentCommand : IRequest<Response<string>>
	{

		public string NameAr { get; set; }
		public string NameEn { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public int DepartmentId { get; set; }
	}
}
