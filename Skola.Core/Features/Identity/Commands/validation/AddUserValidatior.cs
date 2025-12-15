using FluentValidation;
using Microsoft.Extensions.Localization;
using Skola.Core.Features.Identity.Commands.models;
using Skola.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Core.Features.Identity.Commands.validation
{
	public class AddUserValidatior:AbstractValidator<AddUserCommand>
	{

        #region Fields
        private readonly IStringLocalizer<Skola.Core.Resources.SharedResources> _localizer;
        #endregion

        #region Constructors
        public AddUserValidatior(IStringLocalizer<Skola.Core.Resources.SharedResources> localizer)
        {
            _localizer = localizer;
            AddValidationRules();
            AddCustomValidation();

		}
        #endregion

        #region Methods
        public void  AddValidationRules()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

			RuleFor(x => x.UserName)
		       .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
		       .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

			RuleFor(x => x.Email)
		       .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
		       .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

			RuleFor(x => x.Password)
		       .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
		       .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.ConfirmPassword)
               .Equal(x => x.Password).WithMessage(_localizer[SharedResourcesKeys.PasswordNotEqueltheConfirmPassword]);

		}
        public void AddCustomValidation() 
        {

        }

        #endregion






    }
}
