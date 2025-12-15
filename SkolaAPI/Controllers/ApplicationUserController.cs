using MediatR;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using Skola.Core.Features.Identity.Commands.models;
using Skola.Core.Features.Identity.Queries.models;

namespace SkolaAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApplicationUserController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ApplicationUserController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> CreateNewUser([FromBody] AddUserCommand command)
		{
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpGet]
		public async Task<IActionResult> Paginated([FromQuery] GetUserPaginationQuery query)
		{
			var response = await _mediator.Send(query);
			return Ok(response);
		}


		[HttpGet("{id}")]
		public async Task<IActionResult> GetStudentByID([FromRoute] int id)
		{
			var response = (await _mediator.Send(new GetUserByIdQuery(id)));
			return Ok(response);
		}
		[HttpPut]
		public async Task<IActionResult> EditExistingUser([FromBody] EditUserCommand editUser)
		{
			var response = await _mediator.Send(editUser);
			return Ok(response);
		}

		[HttpDelete("{id}")]
	   public async Task<IActionResult> DeleteUser([FromRoute] int id)
	   {
	         var response = await _mediator.Send(new DeleteUserCommand(id));
		     return Ok(response);
	        
	
	   }
		[HttpPut("ChangePassword")]
		public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand changePassword)
		{
			var response = await _mediator.Send(changePassword);
			return Ok(response);
		}
	}
}

