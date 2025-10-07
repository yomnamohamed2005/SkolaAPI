using AutoMapper;
using MediatR;
using Skola.Core.student.Queries.models;
using Skola.Data.Entities;
using Skola.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skola.Core.student.Queries.Dtos;
using Skola.Core.Bases;
using Skola.Core.Wapper;
using Skola.Services.Services;
using System.Linq.Expressions;
using Skola.Core.student.Queries.Response;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Localization;
using Skola.Core.Resources;
namespace Skola.Core.student.Queries.handler
{
	public class StudentHandler : ResponseHandler, IRequestHandler<GetStudentsQuery, Response<List<StudentDto>>>,
								   IRequestHandler<GetStudentQuery, Response<StudentDto>>,
									IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentListPaginationResponse>>
	{
		private readonly IStudentServices _studentservices;
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<Skola.Core.Resources.SharedResources> _stringLocalizer;

		public StudentHandler(IStudentServices studentservices, IMapper mapper, IStringLocalizer<Skola.Core.Resources.SharedResources> stringLocalizer):base(stringLocalizer)
		{
			this._studentservices = studentservices;
			this._mapper = mapper;
			this._stringLocalizer = stringLocalizer;
		}



		public async Task<Response<List<StudentDto>>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
		{
			var studentlist = await _studentservices.GetAllStudents();
			if (studentlist is null) return NotFound<List<StudentDto>>("The List of student Not Found");
			var mappingstudent = _mapper.Map<List<StudentDto>>(studentlist);
			var result = Success(mappingstudent);
			result.Meta = new { Count = mappingstudent.Count() };
			return result;
		}
			public async Task<Response<StudentDto>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
			{
				var student = await _studentservices.GetStudentById(request.Id);
				if (student is null) return NotFound<StudentDto>(_stringLocalizer[SharedResourcesKeys.NotFound]);
				var Mappingstudent = _mapper.Map<StudentDto>(student);
				return Success(Mappingstudent);

			}

			public async Task<PaginatedResult<GetStudentListPaginationResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
			{
				Expression<Func<Student, GetStudentListPaginationResponse>> expression = e => new GetStudentListPaginationResponse(e.Id, e.Localize(e.NameAr,e.NameEn), e.Address, e.Department.Localize(e.NameAr,e.NameEn));
				var FilterQuery = _studentservices.FilterStudentPaginatedQuerable(request.OrderBy, request.Search);
				var PaginatedList = await FilterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
				PaginatedList.Meta = new { Count = PaginatedList.Data.Count() };
				return PaginatedList;

			}

		
	}
}