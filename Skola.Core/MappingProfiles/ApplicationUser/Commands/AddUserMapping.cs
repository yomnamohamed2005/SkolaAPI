using Skola.Core.Features.Identity.Commands.models;
using Skola.Data.Entities.Identity;
namespace Skola.Core.MappingProfiles.ApplicationUser;
public partial class ApplicatonUserProfile
{
	public void AddUserMappings()
	{
		CreateMap<AddUserCommand, User>()
			.ForMember(des => des.FullName, opt => opt.MapFrom(src => src.FullName))
			.ForMember(des => des.UserName, opt => opt.MapFrom(src => src.UserName))
			.ForMember(des => des.Email, opt => opt.MapFrom(src => src.Email))
			.ForMember(des => des.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
			.ForMember(des => des.Address, opt => opt.MapFrom(src => src.Address))
			.ForMember(des => des.Country, opt => opt.MapFrom(src => src.Country));
	}
}
