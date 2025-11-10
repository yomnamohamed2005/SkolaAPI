

namespace Skola.Core.student.Queries.Response
{
	public class GetStudentListPaginationResponse
	{


       public GetStudentListPaginationResponse(int ID, string name, string address, string departmentname)
		{
			StudID = ID;
			Name = name;
			Address = address;
			DepartmentName = departmentname;
		}
		
		public int StudID { get; set; }
		public string? Name { get; set; }
		public string? Address { get; set; }
		public string? DepartmentName { get; set; }
	}
}
