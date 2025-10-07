namespace SkolaAPI.Errors
{
	public class ApiErrorResponse :ErrorResponse
	{
		public string? _Details { get; set; }
        public ApiErrorResponse(int StatueCode, string? ErrrorMessage = null, string? Details = null):base(StatueCode, ErrrorMessage)
		{
            
            _Details = Details;
        }
    }
}
