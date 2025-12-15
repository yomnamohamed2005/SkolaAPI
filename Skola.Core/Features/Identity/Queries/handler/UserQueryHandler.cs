using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Skola.Core.Bases;
using Skola.Core.Features.Identity.Queries.models;
using Skola.Core.Features.Identity.Queries.results;
using Skola.Core.Resources;
using Skola.Core.Wapper;
using Skola.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Core.Features.Identity.Queries.handler
{
	public class UserQueryHandler : ResponseHandler,
								   IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>,
								   IRequestHandler<GetUserPaginationQuery, PaginatedResult<GetUserPaginationResponse>>

	
	{

		#region Fields
		private readonly IStringLocalizer<Resources.SharedResources> _stringLocalizer;
		private readonly IMapper _mapper;
		private readonly UserManager<User> _userManager;
		#endregion

		#region Constructor
		public UserQueryHandler(IMapper mapper, IStringLocalizer<Resources.SharedResources> stringLocalizer, UserManager<User> userManager) : base(stringLocalizer)
		{
			_mapper = mapper;
			_stringLocalizer = stringLocalizer;
			_userManager = userManager;
		}

		#endregion

		public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
		{
			var user =await  _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
			if (user == null)
				return NotFound<GetUserByIdResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
			var mappinguser = _mapper.Map<GetUserByIdResponse>(user);
			return Success(mappinguser);
			
			
		}

		public async Task<PaginatedResult<GetUserPaginationResponse>> Handle(GetUserPaginationQuery request, CancellationToken cancellationToken)
		{
			var users = _userManager.Users.AsQueryable();
			var paginatedlist =await  _mapper.ProjectTo<GetUserPaginationResponse>(users)
									   .ToPaginatedListAsync(request.PageNumber, request.PageSize);
			return paginatedlist;
		}
	}
}
