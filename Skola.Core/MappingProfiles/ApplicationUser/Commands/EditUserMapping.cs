using Skola.Core.Features.Identity.Commands.models;
using Skola.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Core.MappingProfiles.ApplicationUser;

public partial class ApplicatonUserProfile
{
	public void EditUserMapping()
	{
		CreateMap<EditUserCommand, User>()
			.ForMember(des => des.FullName, opt => opt.MapFrom(src => src.FullName))
			.ForMember(des => des.UserName, opt => opt.MapFrom(src => src.UserName))
			.ForMember(des => des.Email, opt => opt.MapFrom(src => src.Email))
			.ForMember(des => des.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
			.ForMember(des => des.Address, opt => opt.MapFrom(src => src.Address))
			.ForMember(des => des.Country, opt => opt.MapFrom(src => src.Country))
			.ForMember(des => des.SecurityStamp, opt => opt.Ignore())
            .ForMember(des => des.PasswordHash, opt => opt.Ignore());
	}
}