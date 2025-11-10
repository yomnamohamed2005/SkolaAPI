using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skola.Core.Fearures.Department.Queries;
using Skola.Core.student.Queries.models;

namespace SkolaAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController : ControllerBase
	{
		private readonly IMediator _mediator;

		public DepartmentController(IMediator mediator)
		{
			this._mediator = mediator;
		}
		[HttpGet]
		public async Task<ActionResult> GetDepartmentById([FromQuery]GetDepartmentByIdRequest query)
		{
			var response = await _mediator.Send(query);
			return Ok(response);
		}
	}
}