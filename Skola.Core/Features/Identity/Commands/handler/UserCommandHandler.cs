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
	public class UserCommandHandler : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>,
									  IRequestHandler<EditUserCommand, Response<string>>,
		                              IRequestHandler<DeleteUserCommand , Response<string>>,
		                              IRequestHandler<ChangePasswordCommand , Response<string>>
	{

		#region Fields
		private readonly IStringLocalizer<Resources.SharedResources> _stringLocalizer;
		private readonly IMapper _mapper;
		private readonly UserManager<User> _userManager;
		#endregion

		#region Constructor
		public UserCommandHandler(IMapper mapper, IStringLocalizer<Resources.SharedResources> stringLocalizer, UserManager<User> userManager) : base(stringLocalizer)
		{
			_mapper = mapper;
			_stringLocalizer = stringLocalizer;
			_userManager = userManager;
		}

		#endregion

		#region Methods
		public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);

			if (user != null)
				return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.EmailIsExist]);

			var userbyusername = await _userManager.FindByNameAsync(request.UserName);

			if (userbyusername != null)
				return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserNameIsExist]);

			var identityuser = _mapper.Map<User>(request);

			var createdresult = await _userManager.CreateAsync(identityuser, request.Password);

			if (!createdresult.Succeeded)
				return BadRequest<string>(createdresult.Errors.FirstOrDefault().Description);
			return Created("");

		}

		public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
		{
			// find user by id 
			var olduser = await _userManager.FindByIdAsync(request.Id.ToString());
			//  if not found return not found 
			if (olduser == null) return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);

			// found and map ,_mapper.Map<EditUserCommand, User>(request);
			var updateduser = _mapper.Map(request, olduser);


			// update 
			var updatedresult = await _userManager.UpdateAsync(updateduser);
			// return success or bad request 
			if (!updatedresult.Succeeded)
			{
				return BadRequest<string>(updatedresult.Errors.FirstOrDefault().Description);

			}
			else
			{
				return Success<string>(_stringLocalizer[SharedResourcesKeys.Updated]);
			}
			#endregion

		}

		public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByIdAsync(request.Id.ToString());
			if (user == null) return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);
			var deletedresult = await _userManager.DeleteAsync(user);
			if (!deletedresult.Succeeded)
			{
				return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.DeletedFailed]);

			}
			else
			{
				return Success<string>(_stringLocalizer[SharedResourcesKeys.Deleted]);
			}
		}

		public async  Task<Response<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if ( user == null )
            {
				return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }
			var changedpasswordresult = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (!changedpasswordresult.Succeeded)
            {
				return BadRequest<string>(changedpasswordresult.Errors.FirstOrDefault().Description);
			}
			else
			{
				return Success<string>(_stringLocalizer[SharedResourcesKeys.changedPasswordsuccessfully]);
			}
        }
	}
}