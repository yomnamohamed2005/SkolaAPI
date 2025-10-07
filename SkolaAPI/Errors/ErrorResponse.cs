namespace SkolaAPI.Errors
{
	public class ErrorResponse
	{
        public int _StatueCode { get; set; }
        public  string? _ErrrorMessage { get; set; }
        public ErrorResponse(int StatueCode, string? ErrrorMessage = null)
        {
            _StatueCode = StatueCode;
            _ErrrorMessage = ErrrorMessage;
        }

        public string GetErrorMessageForSttuesCode(int StatueCode, string? ErrrorMessage= null)
        {
            return StatueCode switch
            {
                404 => "Resourse is Not Found",
                400 => "BadRequest",
                500 => "internal Server Error",
                401 => "You Are ot Authorized",
                _ => null
            };
        }
    }
}
