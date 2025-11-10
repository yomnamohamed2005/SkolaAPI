using MediatR;
using Skola.Core.Bases;


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
