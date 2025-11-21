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
		public async Task<IActionResult> Create([FromBody] AddUserCommand command)
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
	}
}

