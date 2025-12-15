using Skola.Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Core.Features.Identity.Commands.models
{
	public class DeleteUserCommand : IRequest<Response<string>>
	{
        public  int  Id  { get; set; }
        public DeleteUserCommand(int id )
        {

            Id = id; 
        }
    }
}
