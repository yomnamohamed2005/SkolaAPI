using AutoMapper;

namespace Skola.Core.MappingProfiles.Departments
{
	public partial class DepartmentProfile : Profile
	{
        public DepartmentProfile()
        {
			GetDepartmentByIdMapping();

		}
    }
}
