using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Skola.Core.Bases;
using Skola.Core.Features.Identity.Commands.models;
using Skola.Core.Resources;
using Skola.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Core.Features.Identity.Commands.handler
{
	public class AddUserHandler : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
	{

		#region Fields
		private readonly IStringLocalizer<Resources.SharedResources> _stringLocalizer;
		private readonly IMapper _mapper;
		private readonly UserManager<User> _userManager;
		#endregion

		#region Constructor
		public AddUserHandler(IMapper mapper, IStringLocalizer<Resources.SharedResources> stringLocalizer, UserManager<User> userManager) : base(stringLocalizer)
		{
			_mapper = mapper;
			_stringLocalizer = stringLocalizer;
			_userManager = userManager;
		}

		#endregion

		#region Methods
		public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
		{
			var user =  await _userManager.FindByEmailAsync(request.Email);

			if (user != null)
				return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.EmailIsExist]);

			var userbyusername =await _userManager.FindByNameAsync(request.UserName);

			if (userbyusername != null)
				return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserNameIsExist]);

			var identityuser = _mapper.Map<User>(request);

			var createdresult = await _userManager.CreateAsync(identityuser,request.Password);

			if (!createdresult.Succeeded)
				return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToAddUser]);
			return Created("");

		}
		#endregion

	}
}
