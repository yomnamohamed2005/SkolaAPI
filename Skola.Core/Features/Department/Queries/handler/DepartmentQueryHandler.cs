using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Skola.Core.Bases;
using Skola.Core.Fearures.Department.Queries;
using Skola.Core.Wapper;
using Skola.Data.Entities;
using Skola.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Core.Fearures.Department.Queries
{
	public class DepartmentQueryHandler : ResponseHandler, IRequestHandler<GetDepartmentByIdRequest, Response<GetByDepartmentByIdResponse>>
	{

		private readonly IStringLocalizer<Resources.SharedResources> _stringLocalizer;
		private readonly IDepartmentServices _departmentServices;
		private readonly IMapper _mapper;
		private readonly IStudentServices _studentServices;

		public DepartmentQueryHandler(IStringLocalizer<Resources.SharedResources> stringLocalizer
			, IDepartmentServices DepartmentServices
			, IMapper Mapper,
			IStudentServices studentServices) : base(stringLocalizer)
		{
			_stringLocalizer = stringLocalizer;
			_departmentServices = DepartmentServices;
			_mapper = Mapper;
			_studentServices = studentServices;
		}



		public async Task<Response<GetByDepartmentByIdResponse>> Handle(GetDepartmentByIdRequest request, CancellationToken cancellationToken)
		{
			var Department = await _departmentServices.GetDepartmentById(request.Id);
			if (Department == null) return NotFound<GetByDepartmentByIdResponse>(_stringLocalizer[_stringLocalizer["NotFound"]]);
			var MappingDepartment = _mapper.Map<GetByDepartmentByIdResponse>(Department);
			Expression<Func<Student, studentresponse>> expression = e => new studentresponse (e.Id, e.Localize(e.NameAr, e.NameEn));
			var studentQuery = _studentServices.GetStudentByDepartmentIdQuerable(request.Id);
			var paginatedstudent = await studentQuery.Select(expression).ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);

			MappingDepartment.StudentList = paginatedstudent;
			return Success(MappingDepartment); 
		}
	}
}
