using Skola.Core.Features.Identity.Queries.results;
using Skola.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Core.MappingProfiles.ApplicationUser;

public partial class ApplicatonUserProfile
{
	public void GetUserByIdMapping()
	{
		CreateMap<User, GetUserByIdResponse>();
	}
}
