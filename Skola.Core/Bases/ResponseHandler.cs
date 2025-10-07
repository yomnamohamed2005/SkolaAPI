using Microsoft.Extensions.Localization;
using Skola.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Core.Bases
{
	public class ResponseHandler
	{
		//private readonly object _localizer;
		private readonly IStringLocalizer<Skola.Core.Resources.SharedResources> _stringLocalizer;
		public ResponseHandler(IStringLocalizer<Skola.Core.Resources.SharedResources> stringLocalizer)
		{
			
			_stringLocalizer = stringLocalizer;

		}
		public Response<T> Deleted<T>()
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.OK,
				Succeeded = true,
				Message = _stringLocalizer[SharedResourcesKeys.Deleted]
			};
		}
		public Response<T> Success<T>(T entity, object Meta = null)
		{
			return new Response<T>()
			{
				Data = entity,
				StatusCode = System.Net.HttpStatusCode.OK,
				Succeeded = true,
				Message = _stringLocalizer[SharedResourcesKeys.Success],
				Meta = Meta
			};
		}
		public Response<T> Unauthorized<T>()
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.Unauthorized,
				Succeeded = true,
				Message = _stringLocalizer[SharedResourcesKeys.UnAuthorized]
			};
		}
		public Response<T> BadRequest<T>(string Message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.BadRequest,
				Succeeded = false,
				Message = Message == null ? _stringLocalizer[SharedResourcesKeys.BadRequest] : Message
			};
		}
		public Response<T> UnprocessableEntity<T>(string Message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
				Succeeded = false,
				Message = Message == null ? _stringLocalizer[SharedResourcesKeys.UnprocessableEntity] : Message
			};
		}

		public Response<T> NotFound<T>(string message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.NotFound,
				Succeeded = false,
				Message = message == null ? _stringLocalizer[SharedResourcesKeys.NotFound] : message
			};
		}

		public Response<T> Created<T>(T entity, object Meta = null)
		{
			return new Response<T>()
			{
				Data = entity,
				StatusCode = System.Net.HttpStatusCode.Created,
				Succeeded = true,
				Message = _stringLocalizer[SharedResourcesKeys.Created],
				Meta = Meta
			};

		}
	}
}
