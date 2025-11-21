
using MediatR;
using Skola.Core.Bases;
using Skola.Core.Features.Identity.Queries.results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Core.Features.Identity.Queries.models
{
	public class GetUserByIdQuery :IRequest<Response<GetUserByIdResponse>>
	{
        public  int  Id{ get; set; }
        public GetUserByIdQuery(int id )
        {
            Id = id;
        }
    }
}
