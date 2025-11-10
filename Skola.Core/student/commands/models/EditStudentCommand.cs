
using MediatR;
using Skola.Core.Bases;


namespace Skola.Core.student.commands.models
{
	public class EditStudentCommand :IRequest<Response<string>>
	{
        public  int  Id { get; set; }
		public string NameAr { get; set; }
		public string NameEn { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public int DepartmentId { get; set; }
	}
}
