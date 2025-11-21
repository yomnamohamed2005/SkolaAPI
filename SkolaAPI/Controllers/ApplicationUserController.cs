using MediatR;
using Microsoft.AspNetCore.Mvc;
using Skola.Core.Features.Identity.Commands.models;

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
		public async Task<IActionResult> Create([FromBody] AddUserCommand command)
		{
			var response = await _mediator.Send(command);
			return Ok(response); 
		}
	}
}

