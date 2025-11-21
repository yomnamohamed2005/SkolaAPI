using Azure;
using MediatR;
using Skola.Core.Features.Identity.Queries.results;
using Skola.Core.Wapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Core.Features.Identity.Queries.models
{
	public class GetUserPaginationQuery : IRequest<PaginatedResult<GetUserPaginationResponse>>
	{
        public  int  PageNumber { get; set; }

        public  int  PageSize { get; set; }
    }
}
