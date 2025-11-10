using MediatR;
using Skola.Core.Bases;
using Skola.Core.student.Queries.Response;
using Skola.Core.Wapper;
using Skola.Data.Helper;


namespace Skola.Core.student.Queries.models
{
	
		public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentListPaginationResponse>>
	{

	
			public int PageNumber { get; set; }
			public int PageSize { get; set; }
			public StudentOrderingEnum OrderBy { get; set; }
			public string? Search { get; set; }
		}
	}

