using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Skola.Core.Bases;
using Skola.Core.student.commands.models;
using Skola.Data.Entities;
using Skola.Data.Services;


namespace Skola.Core.student.commands.handler
{
	public class StudentCommandHandler :ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>,
		                                                 IRequestHandler<EditStudentCommand,Response<string>>,
		                                                 IRequestHandler<DeleteStudentCommand,Response<string>>
	{
		private readonly IStudentServices _studentServices;
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<Skola.Core.Resources.SharedResources> _stringLocalizer;

		public StudentCommandHandler(IStudentServices studentServices,IMapper mapper ,
				IStringLocalizer< Skola.Core.Resources.SharedResources> stringLocalizer):base(stringLocalizer)
		{ 
			this._studentServices = studentServices;
			this._mapper = mapper;
			this._stringLocalizer = stringLocalizer;
		}
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
		{
			var mappingstudent = _mapper.Map<Student>(request);
			var result = await _studentServices.AddAsyc(mappingstudent);
			if (result == "Exist") return UnprocessableEntity<string>("studeny is already exist");
			else if (result == "Success") return Created("Added Successfully");
			else return BadRequest<string>();
                 
            

        }

		public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
		{
			var student = await _studentServices.GetStudentById(request.Id);
			if (student == null) return NotFound<string>("Student not found");
			var mappingstudent = _mapper.Map(request,student);
			var editstudent = await  _studentServices.EditAsync(mappingstudent);
			if (editstudent == "Success") return Success<string>("Edited Successfully");
			else  return BadRequest<string>();

		}

		public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
		{
			var student = await _studentServices.GetStudentById(request.Id);
			if (student == null) return NotFound<string>("Student not found");
			var deletedstudent = await _studentServices.DeleteAsync(student);
			if (deletedstudent == "Success") return Deleted<string>();
			else return BadRequest<string>();

		}
	}
}
