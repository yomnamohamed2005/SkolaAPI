using MediatR;
using Skola.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Core.student.commands.models
{
	public class DeleteStudentCommand : IRequest<Response<string>>
	{
        public  int Id { get; set; }
        public DeleteStudentCommand(int id )
        {
            Id = id;
        }
    }
}
