
using Azure.Core;
using FluentValidation;
using FluentValidation.Validators;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Core.Behavior
{
	public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : IRequest<TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> _validator;
		private readonly IStringLocalizer<Skola.Core.Resources.SharedResources> _stringLocalizer;

		public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator, IStringLocalizer<Skola.Core.Resources.SharedResources> stringLocalizer)
        {
			this._validator = validator;
			this._stringLocalizer = stringLocalizer;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			var context = new ValidationContext<TRequest>(request);
			var validationresult = await Task.WhenAll(_validator.Select(v => v.ValidateAsync(context, cancellationToken)));
			var failurevalidation = validationresult.SelectMany(v => v.Errors).Where(e => e != null).ToList();
			if(failurevalidation.Count!=0)
			{
				var message = failurevalidation.Select(f => _stringLocalizer[$"{f.PropertyName}"] + ":" +_stringLocalizer[f.ErrorMessage]).FirstOrDefault();
				throw new ValidationException(message);
			}
			return await next();
		}
	}
}
