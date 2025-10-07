using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Skola.Core.student.commands.models;
using Skola.Core.student.Queries.models;
using Skola.Data.Entities;
using SkolaAPI.Errors;

namespace SkolaAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IMediator _mediator;

		public StudentController(IMediator mediator)
        {
			this._mediator = mediator;
		}
		[HttpGet]
		public async Task<ActionResult> GetAlllStudent()
		{
			var response = await _mediator.Send(new GetStudentsQuery());
			return Ok(response);
		}
		[HttpGet("Paginated")]
		public async Task<ActionResult> GetAlllStudentPaginated([FromQuery]GetStudentPaginatedListQuery query)
		{
			var response = await _mediator.Send(query);
			return Ok(response);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult> GetStudentById(int id )
		{
			var response = await _mediator.Send(new GetStudentQuery(id));
			return Ok(response);      
        }
		[HttpPost("Create")]
		public async Task<ActionResult> CreateNewStudent(AddStudentCommand command)
		{
			var response = await _mediator.Send(command);
			return Ok(response);

		}
		[HttpPost("Edit")]
		public async Task<ActionResult> EditStudent(EditStudentCommand command)
		{
			var response = await _mediator.Send(command);
			return Ok(response);
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteStudent (int id )
		{
			var response = await _mediator.Send(new DeleteStudentCommand(id));
			return Ok(response);

		}	
	
	

	}
}
