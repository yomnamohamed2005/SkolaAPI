using AutoMapper;


namespace Skola.Core.MappingProfiles.ApplicationUser;
public partial class ApplicatonUserProfile : Profile
{
	public ApplicatonUserProfile()
	{
		AddUserMappings();
		GetPaginatedUserMapping();
		GetUserByIdMapping();


	}
}

