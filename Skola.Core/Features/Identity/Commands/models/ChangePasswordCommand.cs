using Skola.Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Core.Features.Identity.Commands.models
{
	public class ChangePasswordCommand : IRequest<Response<string>>
	{
        public  int  Id { get; set; }

        public  string  CurrentPassword { get; set; }

        public  string  NewPassword { get; set; }

        public  string  ConfirmNewPassword { get; set; }
    }
}
