using FluentValidation;
using Skola.Data.Services;
using Skola.Core.student.commands.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Core.student.commands.validation
{
	public class EditStudentValidator : AbstractValidator<EditStudentCommand>
	{
		private readonly IStudentServices _studentServices;

        public EditStudentValidator(IStudentServices studentServices)
        {
			_studentServices = studentServices;
			ApplyValidatonrules();
			ApplyCustomValidation();
        }
        public void ApplyValidatonrules()
		{
			RuleFor(s => s.NameEn)
				.NotEmpty().WithMessage(" Name must be  not  empty")
				.NotNull().WithMessage("name must be not null")
				.MaximumLength(20).WithMessage("Name must be maximam length 20 chars");

			RuleFor(s => s.Address)
			  .NotEmpty().WithMessage(" {PropertyName} must be  not  empty")
			  .NotNull().WithMessage(" {PropertyName} must be not null")
			  .MaximumLength(20).WithMessage(" {PropertyName} must be maximam length 20 chars");

		}
		public void ApplyCustomValidation()
		{
			RuleFor(s => s.NameEn)
				.MustAsync(async (command,key ,CancellationToken) => !await _studentServices.IsNameEnEXistWithSelf(key,command.Id))
				.WithMessage("Name is Already Exist");

			RuleFor(s => s.NameAr)
			.MustAsync(async (command, key, CancellationToken) => !await _studentServices.IsNameArEXistWithSelf(key, command.Id))
			.WithMessage("Name is Already Exist");
		}
	}
}