using FluentValidation;
using Microsoft.Extensions.Localization;
using Skola.Core.Resources;
using Skola.Core.student.commands.models;
using Skola.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Core.student.commands.validation
{
	public class AddStudentValidator : AbstractValidator<AddStudentCommand>
	{
		private readonly IStudentServices _studentServices;
		private readonly IStringLocalizer<Skola.Core.Resources.SharedResources> _stringLocalizer;

		public AddStudentValidator(IStudentServices studentServices,IStringLocalizer<Skola.Core.Resources.SharedResources>stringLocalizer)
        {
			// ApplyValidatonrules();
			
			this._studentServices = studentServices;
			this._stringLocalizer = stringLocalizer;
			ApplyValidationRules();

			ApplyCustomValidation();
		}
		public void ApplyValidationRules()
		{
			RuleFor(s => s.NameEn)
				.NotEmpty().WithMessage($"{_stringLocalizer[SharedResourcesKeys.NotEmpty]}")
				.NotNull().WithMessage("{PropertyName} must not be null")
				.MaximumLength(20).WithMessage("{PropertyName} must be a maximum of 20 characters");

			RuleFor(s => s.Address)
				.NotEmpty().WithMessage($"{_stringLocalizer[SharedResourcesKeys.NotEmpty]}")
				.NotNull().WithMessage("{PropertyName} must not be null")
				.MaximumLength(20).WithMessage("{PropertyName} must be a maximum of 20 characters");
		}

		public void ApplyCustomValidation()
        {
            RuleFor(s => s.NameAr)
                .MustAsync(async (key, CancellationToken) => !await _studentServices.IsNameArExist(key))
                .WithMessage("Name is Already Exist");
			RuleFor(s => s.NameEn)
			  .MustAsync(async (key, CancellationToken) => !await _studentServices.IsNameEnExist(key))
			  .WithMessage("Name is Already Exist");
		}
    }
}
